namespace LuckyDefense.Core.Combat
{
    public readonly struct DamageResult
    {
        public readonly int Damage;

        public readonly bool IsDead;

        public DamageResult(int damage, bool isDead)
        {
            Damage = damage;
            IsDead = isDead;
        }
    }
}