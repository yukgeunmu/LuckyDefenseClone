using LuckyDefense.Board;
using LuckyDefense.Board.View;
using LuckyDefense.Core.Events;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Core.Service;
using LuckyDefense.Heroes.View;
using System;
using UnityEngine;
using LuckyDefense.Monster.Data;


namespace LuckyDefense.Core.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public ResourceManager Resource { get; private set; }
        public DataManager Data { get; private set; }
        public BoardManager Board { get; private set; }
        public SpawnManager Spawn { get; private set; }

        public MergeService Merge { get; private set; }

        public PlacementService Placement { get; private set; }

        [SerializeField]
        private HeroDatabase heroDatabase;

        [SerializeField]
        private RecipeDatabase recipeDatabase;

        [SerializeField]
        private MonsterDatabase monsterDatabase;




        private HeroFactory heroFactory;

        private HeroViewFactory heroViewFactory;


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
            Placement = new PlacementService(Board);

            Data.Init(heroDatabase, recipeDatabase, monsterDatabase);
        }

    }
}
