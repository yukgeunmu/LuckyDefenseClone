using LuckyDefense.Board.View;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.View;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LuckyDefense.Board
{

    public class HeroStackDragController : MonoBehaviour
    {
        [SerializeField]
        private Camera mainCamera;

        private HeroStackView selectedStack;

        private Vector3 originalPosition;
        private Vector3 offset;

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
            Vector2 mouse = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(mouse, Vector2.zero);

            if (!hit)
                return;

            HeroStackView stack = hit.collider.GetComponentInChildren<HeroStackView>();

            if (stack == null)
                return;
            
            selectedStack = stack;

            originalPosition = stack.transform.position;

            offset = stack.transform.position - (Vector3)mouse;
        }

        private void Drag()
        {
            if (selectedStack == null)
                return;

            Vector2 mouse =  mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            selectedStack.transform.position =  mouse + (Vector2)offset;
        }

        private void EndDrag()
        {
            if (selectedStack == null)
                return;

            Vector2 mouse =   mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(mouse, Vector2.zero);

            if (hit)
            {
                CellView target = hit.collider.GetComponent<CellView>();

                if (target != null)
                {
                    GridCell sourceCell = selectedStack.OwnerCell.GridCell;

                    GridCell targetCell = target.GridCell;

                    GameManager.Instance.Placement.MoveStack(sourceCell, targetCell);
                }
            }

            selectedStack.transform.position = originalPosition;

            selectedStack = null;
        }
    }


}

