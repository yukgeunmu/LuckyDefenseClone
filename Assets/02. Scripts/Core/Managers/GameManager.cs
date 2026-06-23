using LuckyDefense.Board;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Heroes.Merge;
using System;
using UnityEngine;


namespace LuckyDefense.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public ResourceManager Resource { get; private set; }
        public DataManager Data { get; private set; }
        public BoardManager Board { get; private set; }
        public SpawnManager Spawn { get; private set; }

        public MergeService Merge { get; private set; }

        [SerializeField]
        private HeroDatabase heroDatabase;

        [SerializeField]
        private RecipeDatabase recipeDatabase;

        private HeroFactory heroFactory;


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
            heroFactory = new HeroFactory();

            Resource = new ResourceManager();
            Data = new DataManager();
            Board = new BoardManager();
            Spawn = new SpawnManager(heroFactory);
            Merge = new MergeService(heroFactory);

            Data.Init(heroDatabase, recipeDatabase);
        }
    }
}
