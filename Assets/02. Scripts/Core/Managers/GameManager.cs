using LuckyDefense.Core.Service;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Heroes.Runtime;
using LuckyDefense.Heroes.View;
using LuckyDefense.Monsters.Data;
using LuckyDefense.Monsters.Factory;
using LuckyDefense.Monsters.View;
using LuckyDefense.Skill;
using LuckyDefense.StatusEffects.Data;
using LuckyDefense.UI.Base;
using LuckyDefense.UI.Data;
using LuckyDefense.Wave.Data;
using UnityEngine;


namespace LuckyDefense.Core.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public DataManager Data { get; private set; }
        public ResourceManager Resource { get; private set; }
        public BoardManager Board { get; private set; }
        public SpawnManager Spawn { get; private set; }

        public WaveManager Wave { get; private set; }

        public PathManager Path { get; private set; }

        public HeroViewManager HeroView { get; private set; }

        public ProjectileManager ProjectileManager { get; private set; }

        public MonsterViewManager MonsterView { get; private set; }

        public UIManager UI { get; private set; }

        public PoolManager Pool { get; private set; }

        public MergeService Merge { get; private set; }

        public PlacementService Placement { get; private set; }

        public DamageService Damage { get; private set; }

        public TargetService Target { get; private set; }

        public HeroStateServie HeroState { get; private set; }

        public ProjectileService Projectile { get; private set; }

        public OrbitService Orbit { get; private set; }

        public SkillService Skill { get; private set; }

        public StatusEffectService StatusEffect { get; private set; }

        public CellSelectionService CellSelection { get; private set; }

        public HeroSellService HeroSell { get; private set; }

        public GoodsService Goods { get; private set; }


        [SerializeField]
        private HeroDatabase heroDatabase;

        [SerializeField]
        private RecipeDatabase recipeDatabase;

        [SerializeField]
        private MonsterDatabase monsterDatabase;

        [SerializeField]
        private WaveDatabase waveDatabase;

        [SerializeField]
        private StatusEffectDatabase statusEffectDatabase;

        [SerializeField]
        private HeroSummonTable summonTable;

        [SerializeField]
        private UIDatabase uiDatabase;

        [SerializeField]
        private Transform pathRoot;

        [SerializeField]
        private CanvasRoot canvasRoot;

        private HeroFactory heroFactory;

        private MonsterFactory monsterFactory;

        private SkillFactory skillFactory;


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

        public void Init()
        {
            skillFactory = new SkillFactory();
            heroFactory = new HeroFactory(skillFactory);
            monsterFactory = new MonsterFactory();

            Resource = new ResourceManager();
            Goods = new GoodsService();
            Data = new DataManager();
            Board = new BoardManager();
            Spawn = new SpawnManager(heroFactory, monsterFactory);
            Wave = new WaveManager();
            Path = new PathManager();
            UI = new UIManager();
            Pool = new PoolManager();

            HeroView = new HeroViewManager();
            MonsterView = new MonsterViewManager();
            ProjectileManager = new ProjectileManager();

            Merge = new MergeService(heroFactory);
            Placement = new PlacementService(Board);
            Damage = new DamageService();
            Target = new TargetService();
            HeroState = new HeroStateServie();
            Projectile = new ProjectileService(heroFactory, ProjectileManager);
            Orbit = new OrbitService();
            Skill = new SkillService();
            StatusEffect = new StatusEffectService();
            CellSelection = new CellSelectionService();
            HeroSell = new HeroSellService();


            Data.Init(heroDatabase,
                recipeDatabase,
                monsterDatabase,
                waveDatabase,
                statusEffectDatabase,
                summonTable,
                uiDatabase);
            Path.Initialize(pathRoot);

            UI.Initialize(canvasRoot);

        }

        public void StartGame()
        {
            Goods.AddGold(99999);
            Wave.StartGame();
        }

    }
}
