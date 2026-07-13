using UnityEngine;

namespace LuckyDefense.UI.Base
{
    public class CanvasRoot : MonoBehaviour
    {
        [SerializeField] private Transform sceneRoot;
        [SerializeField] private Transform popupRoot;

        public Transform SceneRoot => sceneRoot;
        public Transform PopupRoot => popupRoot;
    }
}