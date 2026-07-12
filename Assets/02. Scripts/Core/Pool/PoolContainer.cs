using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.Core.Pool
{
    /// <summary>
    /// 하나의 Prefab을 관리하는 Pool
    /// </summary>
    public class PoolContainer<T> : IPoolContainer where T : Component, IPoolable
    {
        private readonly Queue<T> pool = new();

        private readonly AssetReferenceGameObject prefabRef;

        private readonly Transform root;

        private readonly int maxSize;

        private GameObject prefab;

        public PoolContainer(
            AssetReferenceGameObject prefabRef,
            GameObject prefab,
            Transform root,
            int maxSize = 100)
        {
            this.prefabRef = prefabRef;
            this.prefab = prefab;
            this.root = root;
            this.maxSize = Mathf.Max(1, maxSize);
        }

        /// <summary>
        /// Pool에서 오브젝트 획득
        /// </summary>
        public T Get(Transform root = null)
        {
            T component = pool.Count > 0 ? pool.Dequeue() : CreateInstance();

            component.transform.SetParent(this.root, false);

            component.OnSpawn();

            component.gameObject.SetActive(true);

            return component;
        }

        /// <summary>
        /// Pool 반환
        /// </summary>
        public void Release(T component)
        {
            if (component == null)
                return;


            if (pool.Count >= maxSize)
            {
                Object.Destroy(component);
                return;
            }

            component.OnDespawn();

            component.gameObject.SetActive(false);

            component.transform.SetParent(root, false);

            pool.Enqueue(component);

        }

        /// <summary>
        /// 미리 생성
        /// </summary>
        public void Prewarm(int count)
        {
            count = Mathf.Max(0, count);

            while (pool.Count < count)
            {
                T obj = CreateInstance();

                Release(obj);
            }
        }

        /// <summary>
        /// Pool 제거
        /// </summary>
        public void Clear()
        {
            while (pool.Count > 0)
            {
                T obj = pool.Dequeue();

                if (obj != null)
                {
                    Object.Destroy(obj);
                }
            }
        }

        /// <summary>
        /// 새로운 인스턴스 생성
        /// </summary>
        private T CreateInstance()
        {
            GameObject obj = Object.Instantiate(prefab);

            T component  = obj.GetComponent<T>();

            obj.name = prefab.name;

            PoolIdentity identity = obj.GetComponent<PoolIdentity>();

            if (identity == null)
            {
                identity = obj.AddComponent<PoolIdentity>();
            }

            identity.Initialize(prefabRef, this, component);

            return component;
        }

        public void Release(IPoolable poolable)
        {
            Release((T)poolable);
        }
    }
}