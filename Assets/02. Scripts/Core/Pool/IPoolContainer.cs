using UnityEngine;


namespace LuckyDefense.Core.Pool
{
    public interface IPoolContainer
    {
        void Clear();
        void Release(IPoolable poolable);
    }
}

