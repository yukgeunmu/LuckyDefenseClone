using LuckyDefense.Monsters;
using System.Collections.Generic;

namespace LuckyDefense.StatusEffects
{
    public class MonsterStatusComponent
    {
        private readonly Monster monster;

        private readonly List<StatusEffect> effects = new();

        public MonsterStatusComponent(Monster monster)
        {
            this.monster = monster;
        }

        public void AddEffect(StatusEffect effect)
        {
            foreach (var current in effects)
            {
                if (current.Type != effect.Type)
                    continue;

                switch (current.StackType)
                {
                    case StatusStackType.Replace:
                        current.Exit();
                        effects.Remove(current);
                        break;
                    case StatusStackType.MaxDuration:
                        current.Refresh(effect);
                        return;
                    case StatusStackType.AddDuration:
                        current.Refresh(effect);
                        return;
                    case StatusStackType.Stack:
                        break;
                }
            }

            effect.Enter();

            effects.Add(effect);

        }

        public void Update()
        {
            for (int i = effects.Count - 1; i >= 0; i--)
            {
                var effect = effects[i];

                effect.Update();

                if (effect.IsFinished)
                {
                    effect.Exit();

                    effects.RemoveAt(i);
                }
            }
        }

    }
}