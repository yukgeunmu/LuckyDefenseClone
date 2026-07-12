using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LuckyDefense.Core.Pool
{
    /// <summary>
    /// Pool에 속한 GameObject의 식별자
    /// </summary>
    public class PoolIdentity : MonoBehaviour
    {
        /// <summary>
        /// 원본 Prefab
        /// </summary>
        public AssetReferenceGameObject Prefab { get; private set; }

        /// <summary>
        /// 자신이 속한 Pool
        /// </summary>
        public IPoolContainer Pool { get; private set; }

        public IPoolable Poolable { get; private set; }

        public void Initialize(AssetReferenceGameObject prefab,  IPoolContainer pool, IPoolable pooable)
        {
            Prefab = prefab;
            Pool = pool;
            Poolable = pooable;
        }
    }
}