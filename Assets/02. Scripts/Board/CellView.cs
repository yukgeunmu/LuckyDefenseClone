using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.View;
using System;
using UnityEngine;

namespace LuckyDefense.Board.View
{
    public class CellView : MonoBehaviour
    {

        [SerializeField]
        private HeroStackView heroStackView;

        public HeroStackView HeroStackView => heroStackView;


        public GridCell GridCell
        {
            get
            {
                return GameManager.Instance.Board.GetCell(CellIndex);
            }
        }

        [field: SerializeField]
        public int CellIndex { get; private set; }


        public void Init(int index)
        {
            CellIndex = index;

            heroStackView.Initialize(this);
        }

    }
}