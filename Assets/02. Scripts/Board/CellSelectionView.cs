using UnityEngine;

namespace LuckyDefense.Board
{
    public class CellSelectionView : MonoBehaviour
    {
        [SerializeField]
        private GameObject selectionObject;

        public void Show()
        {
            selectionObject.SetActive(true);
        }

        public void Hide()
        {
            selectionObject.SetActive(false);
        }
    }
}