using LuckyDefense.Heroes.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



namespace LuckyDefense.UI.Scene
{
    public class SpawnBtnPanel : MonoBehaviour
    {
        [SerializeField] private Image titleImage;
        [SerializeField] private TextMeshProUGUI percentText;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private Button spawnButton;

        public Button SpawnButton => spawnButton;
    }
}

