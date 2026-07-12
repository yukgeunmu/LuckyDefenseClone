using LuckyDefense.Core.Events;
using LuckyDefense.Core.Pool;
using TMPro;
using UnityEngine;

namespace LuckyDefense.UI
{
    public class DamageTextView : MonoBehaviour, IPoolable
    {
        [SerializeField]
        private TextMeshPro text;

        private float MaxLife = 0.7f;

        private float life;

        public void Initialize( float damage, bool critical)
        {
            text.text = Mathf.RoundToInt(damage).ToString();

            if (critical)
            {
                text.text = $"CRIT\n{text.text}";
            }
        }


        private void Update()
        {
            transform.position +=
                Vector3.up *
                2f *
                Time.deltaTime;

            life -= Time.deltaTime;

            if (life <= 0)
            {
                EventBus.Publish(new DamageTextExpiredEvent(this));
            }
        }

        public void OnSpawn()
        {
            life = MaxLife;

            text.alpha = 1.0f;
        }

        public void OnDespawn()
        {
            text.text = "";
        }

    }
}