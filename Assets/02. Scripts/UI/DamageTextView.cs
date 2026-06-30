using TMPro;
using UnityEngine;

namespace LuckyDefense.UI
{
    public class DamageTextView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro text;

        private float life = 0.7f;

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
                Destroy(gameObject);
            }
        }
    }
}