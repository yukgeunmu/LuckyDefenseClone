namespace LuckyDefense.Core.Pool
{
    /// <summary>
    /// Pool에서 Spawn/Despawn 시 호출되는 인터페이스
    /// </summary>
    public interface IPoolable
    {
        /// <summary>
        /// Pool에서 꺼내질 때 호출
        /// </summary>
        void OnSpawn();

        /// <summary>
        /// Pool로 반환될 때 호출
        /// </summary>
        void OnDespawn();
    }
}