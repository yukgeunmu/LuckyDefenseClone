using Cysharp.Threading.Tasks;
using LuckyDefense.Core.Pool;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.Core.Manager
{
    public class PoolManager
    {
        private readonly Dictionary<AssetReferenceGameObject, IPoolContainer> pools = new();

        private readonly Transform root;

        public PoolManager()
        {
            GameObject rootObj = new GameObject("[Pool]");
            Object.DontDestroyOnLoad(rootObj);

            root = rootObj.transform;
        }

        /// <summary>
        /// Pool에서 GameObject를 가져온다.
        /// </summary>
        //public async UniTask<GameObject> Get(AssetReferenceGameObject prefabRef)
        //{
        //    if (prefabRef == null)
        //    {
        //        Debug.LogError("[Pool] Prefab Reference is null.");
        //        return null;
        //    }

        //    PoolContainer pool = await GetOrCreatePool(prefabRef);

        //    return pool.Get();
        //}

        public async UniTask<T> Get<T>(AssetReferenceGameObject prefab) where T : Component, IPoolable
        {
            PoolContainer<T> pool =  await GetOrCreatePool<T>(prefab);

            return pool.Get();
        }

        /// <summary>
        /// Pool로 반환한다.
        /// </summary>
        public void Release(GameObject obj)
        {
            if (obj == null)
                return;

            if (!obj.TryGetComponent(out PoolIdentity identity))
            {
                Object.Destroy(obj);
                return;
            }

            identity.Pool.Release(identity.Poolable);
        }

        /// <summary>
        /// 미리 생성
        /// </summary>
        public async UniTask Prewarm<T>( AssetReferenceGameObject prefabRef, int count) where T : Component, IPoolable
        {
            if (count <= 0)
                return;

           PoolContainer<T> pool =  await GetOrCreatePool<T>(prefabRef);

           pool.Prewarm(count);
        }

        /// <summary>
        /// 모든 Pool 제거
        /// </summary>
        public void Clear()
        {
            foreach (IPoolContainer pool in pools.Values)
            {
                pool.Clear();
            }

            pools.Clear();
        }

        /// <summary>
        /// Pool 생성 또는 가져오기
        /// </summary>
        private async UniTask<PoolContainer<T>> GetOrCreatePool<T>(AssetReferenceGameObject prefabRef) where T : Component, IPoolable
        {
            // 1차 검사: 이미 생성된 풀이 있다면 즉시 반환
            if (pools.TryGetValue(prefabRef, out IPoolContainer container))
            {
                return (PoolContainer<T>)container;
            }


            // 비동기 로드 시작 (여기서 제어권이 넘어가며 다른 호출이 들어올 수 있음)
            GameObject prefab = await GameManager.Instance.Resource.LoadAsync<GameObject>(prefabRef);

            // 2차 검사 (Double-Check): await 하는 동안 다른 호출이 먼저 풀을 생성했는지 확인
            if (pools.TryGetValue(prefabRef, out container))
            {
                // Addressables는 내부적으로 동일 에셋 다중 로드 시 레퍼런스 카운트만 올리므로, 
                // 여기서 바로 기존 풀을 반환해도 안전합니다.
                return (PoolContainer<T>)container;
            }

            // 여기서부터는 다음 await를 만나기 전까지 중간에 다른 코드가 끼어들 수 없음 (원자성 보장)
            GameObject poolRoot = new GameObject(prefab.name);
            poolRoot.transform.SetParent(root);

            PoolContainer<T>  pool = new PoolContainer<T>(
                prefabRef,
                prefab,
                poolRoot.transform);

            // 2차 검사를 통과했으므로 이제 안전하게 Add할 수 있습니다.
            pools.Add(prefabRef, pool);

            return pool;
        }


    }
}