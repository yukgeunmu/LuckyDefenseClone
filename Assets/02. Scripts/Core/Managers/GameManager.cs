using UnityEngine;


namespace LuckyDefense.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public ResourceManager Resource { get; private set; }
        public DataManager Data { get; private set; }


        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            Init();
        }

        private void Init()
        {
            Resource = new ResourceManager();
            Data = new DataManager();
        }
    }
}
