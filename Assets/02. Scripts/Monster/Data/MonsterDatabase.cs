

using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Monsters.Data
{
    [CreateAssetMenu(menuName = "Game/Monster/Monster Database", fileName = "MonsterDatabase")]
    public class MonsterDatabase : ScriptableObject
    {
        public List<MonsterData> Monsters = new();
    }
}