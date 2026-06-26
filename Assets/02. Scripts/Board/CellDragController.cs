using LuckyDefense.Board.View;
using UnityEngine;
using UnityEngine.InputSystem;


namespace LuckyDefense.Board
{
    public class CellDragController : MonoBehaviour
    {
        private Camera mainCamera;

        private CellView selectedCell;
        private Vector3 originalPosition;
        private Vector3 dragOffset;


        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            HandleDrag();
        }

        private void HandleDrag()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                BeginDrag();
            }


            if (Mouse.current.leftButton.isPressed)
            {
                Drag();
            }

            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                EndDrag();
            }


        }

        private void BeginDrag()
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast( mousePosition, Vector2.zero);

            if (hit.collider == null)
                return;

            CellView cellView =  hit.collider.GetComponent<CellView>();

            if (cellView == null)
                return;

            if (cellView.GridCell.IsEmpty)
                return;

            selectedCell = cellView;

            originalPosition = selectedCell.transform.position;

            dragOffset = selectedCell.transform.position - (Vector3)mousePosition;


        }

        private void Drag()
        {
            if (selectedCell == null)
                return;


            Vector2 mousePosition =
                mainCamera.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue());

            selectedCell.transform.position =
                mousePosition + (Vector2)dragOffset;
        }


        private void EndDrag()
        {
            if (selectedCell == null)
                return;


            Vector2 mousePosition =
                mainCamera.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue());

            RaycastHit2D hit =
                Physics2D.Raycast(
                    mousePosition,
                    Vector2.zero);

            if (hit.collider != null)
            {
                CellView targetCell =
                    hit.collider.GetComponent<CellView>();

                if (targetCell != null)
                {
                    Debug.Log(
                        $"Drop : {selectedCell.name} -> {targetCell.name}");
                }
            }

            selectedCell.transform.position =
                originalPosition;

            selectedCell = null;


        }



    }
}

