using LuckyDefense.Core.Manager;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Board.View
{
    public class BoardView : MonoBehaviour
    {
        [SerializeField]
        private List<CellView> cellViews;

        private void Awake()
        {
            for (int i = 0; i < cellViews.Count; i++)
            {
                cellViews[i].Init(i);
            }
        }

        public CellView GetCellView(int index)
        {
            if (index < 0 ||
                index >= cellViews.Count)
                return null;

            return cellViews[index];
        }

        public GridCell GetGridCell(CellView cellView)
        {
            return GameManager.Instance.Board
                .GetCell(cellView.CellIndex);
        }
    }
}