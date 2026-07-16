using LuckyDefense.Board.View;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.View;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace LuckyDefense.Board
{

    public class HeroStackInputController : MonoBehaviour
    {
        [SerializeField]
        private Camera mainCamera;

        [SerializeField]
        private float dragThreshold = 15f;

        private HeroStackView selectedStack;

        private Vector3 originalPosition;
        private Vector3 offset;


        private Vector2 pressScreenPosition;

        private bool isDragging;

        private bool isPressed;

        private bool IsPointerOnUI()
        {
            return EventSystem.current != null &&
                   EventSystem.current.IsPointerOverGameObject();
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (IsPointerOnUI())
                return;


            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                OnMouseDown();
            }


            if (Mouse.current.leftButton.isPressed)
            {
                OnMouseDrag();
            }

            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                OnMouseUp();
            }
        }

        private void OnMouseDown()
        {

            Vector2 mouse = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(mouse, Vector2.zero);

            if (!hit)
                return;

            HeroStackView stack = hit.collider.GetComponentInChildren<HeroStackView>();

            if (stack == null)
                return;

            if (stack.HeroViews.Count <= 0)
                return;

            selectedStack = stack;

            pressScreenPosition = Mouse.current.position.ReadValue();

            originalPosition = stack.transform.position;

            isPressed = true;
            isDragging = false;

        }

        private void OnMouseDrag()
        {
            if (!isPressed || selectedStack == null)
                return;

            // 아직 드래그가 시작되지 않았다면 Threshold 검사
            if (!isDragging)
            {
                float distance =
                    Vector2.Distance(
                        Mouse.current.position.ReadValue(),
                        pressScreenPosition);

                if (distance < dragThreshold)
                    return;

                // 여기서부터 Drag 시작
                isDragging = true;

                Vector2 mouse =
                    mainCamera.ScreenToWorldPoint(
                        Mouse.current.position.ReadValue());

                offset =
                    selectedStack.transform.position -
                    (Vector3)mouse;

                GameManager.Instance.CellSelection.Deselect();
            }

            Drag();
        }

        private void Drag()
        {
            Vector2 mouse =
                mainCamera.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue());

            selectedStack.transform.position =
                mouse + (Vector2)offset;
        }

        private void OnMouseUp()
        {

            if (!isPressed || selectedStack == null)
            {
                ResetState();
                return;
            }

            if (!isDragging)
            {
                // 클릭
                GameManager.Instance
                    .CellSelection
                    .Select(selectedStack.OwnerCell.GridCell);
            }
            else
            {
                // 드래그 종료
                Drop();
            }

            selectedStack.transform.position = originalPosition;

            ResetState();
        }

        private void Drop()
        {
            Vector2 mouse =
                mainCamera.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue());

            RaycastHit2D hit =
                Physics2D.Raycast(mouse, Vector2.zero);

            if (!hit)
                return;

            CellView target =
                hit.collider.GetComponent<CellView>();

            if (target == null)
                return;

            GridCell sourceCell =
                selectedStack.OwnerCell.GridCell;

            GridCell targetCell =
                target.GridCell;

            GameManager.Instance
                .Placement
                .MoveStack(sourceCell, targetCell);

            GameManager.Instance.CellSelection.Deselect();
        }



        private void ResetState()
        {
            selectedStack = null;
            isPressed = false;
            isDragging = false;
        }

    }


}

