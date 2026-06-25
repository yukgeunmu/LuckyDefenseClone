using LuckyDefense.Heroes.View;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LuckyDefense.Board.View
{
    public class CellView : MonoBehaviour, IDropHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField]
        private Transform heroContainer;

        public Transform HeroContainer => heroContainer;

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

        public void OnBeginDrag(PointerEventData eventData)
        {
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }

        public void Refresh()
        {
            int childCount = heroContainer.childCount;
            if (childCount <= 1) return;

            // 원의 반지름
            float radius = 0.2f;

            // 개수별로 시작 위치(Offset)를 다르게 설정
            float angleOffset = 0f;

            if (childCount == 2)
            {
                // 2개일 때는 0도(3시 방향)부터 시작 -> 3시, 9시 배치
                angleOffset = 0f;
            }
            else if (childCount == 3)
            {
                // 3개일 때는 90도(12시 방향)부터 시작 -> 12시, 8시, 4시(정삼각형) 배치
                angleOffset = MathF.PI / 2f;
            }
            // (참고) 1개일 때는 기본 0f로 두면 정중앙이 아니므로, 
            // 만약 1개일 때 정중앙에 두고 싶다면 좌표를 0,0,0으로 밀어주는 예외처리를 하셔도 좋습니다.

            for (int i = 0; i < childCount; i++)
            {
                Transform hero = heroContainer.GetChild(i);

                // 1개만 있을 때는 회전 계산 없이 정중앙(0, 0)에 배치
                if (childCount == 1)
                {
                    hero.localPosition = Vector3.zero;
                    continue;
                }

                // 각도 계산 (기본 분할 각도 + 개수별 보정 각도)
                float angle = (i * MathF.PI * 2f / childCount) + angleOffset;

                // 좌표 대입
                float x = MathF.Cos(angle) * radius;
                float y = MathF.Sin(angle) * radius;

                hero.localPosition = new Vector3(x, y, 0);
            }
        }
    }
}