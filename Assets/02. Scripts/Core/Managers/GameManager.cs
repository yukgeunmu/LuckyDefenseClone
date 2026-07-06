using LuckyDefense.Core.Combat;
using LuckyDefense.Core.Service;
using LuckyDefense.Heroes.Data;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Heroes.Runtime;
using LuckyDefense.Heroes.View;
using LuckyDefense.Monsters.Data;
using LuckyDefense.Monsters.Factory;
using LuckyDefense.Monsters.View;
using LuckyDefense.Skill;
using LuckyDefense.Skill.Data;
using LuckyDefense.Skill.View;
using LuckyDefense.StatusEffects.Data;
using LuckyDefense.Wave.Data;
using UnityEngine;


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

        public HeroViewManager HeroView { get; private set; }

        public HeroCombatManager HeroCombat { get; private set; }

        public ProjectileManager ProjectileManager { get; private set; }

        public MonsterViewManager MonsterView { get; private set; }

        public MergeService Merge { get; private set; }

        public PlacementService Placement { get; private set; }

        public DamageService Damage { get; private set; }

        public TargetService Target { get; private set; }

        public CombatService Combat { get; private set; }

        public ProjectileService Projectile { get; private set; }

        public SkillService Skill { get; private set; }

        public StatusEffectService StatusEffect { get; private set; }


        [SerializeField]
        private HeroDatabase heroDatabase;

        [SerializeField]
        private RecipeDatabase recipeDatabase;

        [SerializeField]
        private MonsterDatabase monsterDatabase;

        [SerializeField]
        private WaveDatabase waveDatabase;

        [SerializeField]
        private SkillEffectDatabase skillEffectDatabase;

        [SerializeField]
        private StatusEffectDatabase statusEffectDatabase;

        [SerializeField]
        private SkillProjectileDatabase skillProjectileDatabase;

        [SerializeField]
        private Transform pathRoot;

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
            Data = new DataManager();
            Board = new BoardManager();
            Spawn = new SpawnManager(heroFactory, monsterFactory);
            Wave = new WaveManager();
            Path = new PathManager();

            HeroView = new HeroViewManager();
            MonsterView = new MonsterViewManager();
            HeroCombat = new HeroCombatManager();
            ProjectileManager = new ProjectileManager();

            Merge = new MergeService(heroFactory);
            Placement = new PlacementService(Board);
            Damage = new DamageService();
            Target = new TargetService();
            Combat = new CombatService(HeroCombat);
            Projectile = new ProjectileService(heroFactory, ProjectileManager);
            Skill = new SkillService();
            StatusEffect = new StatusEffectService();


            Data.Init(heroDatabase, 
                recipeDatabase,
                monsterDatabase,
                waveDatabase,
                skillEffectDatabase,
                statusEffectDatabase,
                skillProjectileDatabase);
            Path.Initialize(pathRoot);
        }

        public void StartGame()
        {
            WaveTest();

            Wave.StartGame();
        }

        public void WaveTest()
        {
            GameManager.Instance.Resource.AddSilver(1000);

            for (int i = 0; i < 1; i++)
            {
                Spawn.SummonHero();
            }
        }

    }
}
