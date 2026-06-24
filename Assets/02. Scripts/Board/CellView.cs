using LuckyDefense.Heroes;
using LuckyDefense.Heroes.View;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LuckyDefense.Board.View
{
    public class CellView : MonoBehaviour, IDropHandler
    {
        [field: SerializeField]
        public int CellIndex { get; private set; }


        public void Init(int index)
        {
            CellIndex = index;
        }

        public void OnDrop(PointerEventData eventData)
        {
            HeroView heroView = eventData.pointerDrag.GetComponent<HeroView>();

            if (heroView == null)
                return;
        }
    }
}