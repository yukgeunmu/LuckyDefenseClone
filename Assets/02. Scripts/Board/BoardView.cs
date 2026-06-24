using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Board.View
{
    public class BoardView : MonoBehaviour
    {
        [SerializeField]
        private List<CellView> cellViews;

        public CellView GetCellView(int index)
        {
            if (index < 0 ||
                index >= cellViews.Count)
                return null;

            return cellViews[index];
        }
    }
}