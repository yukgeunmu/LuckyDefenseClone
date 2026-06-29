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
using LuckyDefense.Monsters.Data;
using LuckyDefense.Monsters.Factory;
using LuckyDefense.Wave.Data;
using LuckyDefense.Monsters.View;
using LuckyDefense.Core.Combat;


namespace LuckyDefense.Core.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public ResourceManager Resource { get; private set; }
        public DataManager Data { get; private set; }
        public BoardManager Board { get; private set; }
        public SpawnManager Spawn { get; private set; }

        public WaveManager Wave { get; private set; }

        public PathManager Path { get; private set; }

        public HeroViewManager HeroView {  get; private set; }

        public HeroCombatManager HeroCombat { get; private set; }

        public MonsterViewManager MonsterView {  get; private set; }

        public MergeService Merge { get; private set; }

        public PlacementService Placement { get; private set; }

        public DamageService Damage { get; private set; }

        public TargetService Target { get; private set; }

        public CombatService Combat { get; private set; }


        [SerializeField]
        private HeroDatabase heroDatabase;

        [SerializeField]
        private RecipeDatabase recipeDatabase;

        [SerializeField]
        private MonsterDatabase monsterDatabase;

        [SerializeField]
        private WaveDatabase waveDatabase;

        [SerializeField]
        private Transform pathRoot;

        private HeroFactory heroFactory;

        private MonsterFactory monsterFactory;


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

        private void OnDrawGizmos()
        {
            if (GameManager.Instance == null)
                return;

            GameManager.Instance
                .Path
                ?.DrawGizmos();
        }

        private void Init()
        {
            heroFactory = new HeroFactory();
            monsterFactory = new MonsterFactory();

            Resource = new ResourceManager();
            Data = new DataManager();
            Board = new BoardManager();
            Spawn = new SpawnManager(heroFactory, monsterFactory);
            Wave = new WaveManager();
            Path = new PathManager();

            HeroView = new HeroViewManager();
            MonsterView = new MonsterViewManager();
            HeroCombat = new HeroCombatManager();

            Merge = new MergeService(heroFactory);
            Placement = new PlacementService(Board);
            Damage = new DamageService();
            Target = new TargetService();
            Combat = new CombatService(HeroCombat, Target, Damage);


            Data.Init(heroDatabase, recipeDatabase, monsterDatabase, waveDatabase);
            Path.Initialize(pathRoot);
        }

    }
}
