using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.View;
using UnityEngine;

namespace LuckyDefense.Board.View
{
    public class CellView : MonoBehaviour
    {

        [SerializeField]
        private HeroStackView heroStackView;

        public HeroStackView HeroStackView => heroStackView;

        [SerializeField]
        private CellSelectionView selectionView;

        [SerializeField]
        private AttackRangeView attackRangeView;


        public CellSelectionView SelectionView => selectionView;

        public AttackRangeView AttackRangeView => attackRangeView;


        public GridCell GridCell
        {
            get
            {
                if (GameManager.Instance == null || GameManager.Instance.Board == null)
                {
                    return null;
                }

                return GameManager.Instance.Board.GetCell(CellIndex);
            }
        }

        [field: SerializeField]
        public int CellIndex { get; private set; }


        public void Init(int index)
        {
            CellIndex = index;

            heroStackView.Initialize(this);

            // GridCell이 null인지 확인 후 대입
            GridCell cell = GridCell;
            if (cell != null)
            {
                cell.WorldPosition = this.transform.position;
            }
        }

    }
}