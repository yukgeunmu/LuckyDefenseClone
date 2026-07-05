

using UnityEngine;

namespace LuckyDefense.Skill.View
{
    public class WhirlwindSkillEffectView : SkillEffectView
    {

        private float timer = 0.5f;
        public override void Play()
        {
        }

        // Update is called once per frame
        void Update()
        {
            transform.localScale += Vector3.one * Time.deltaTime * 5f;

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

