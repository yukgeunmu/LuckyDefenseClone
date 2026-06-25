using LuckyDefense.Board;
using LuckyDefense.Board.View;
using LuckyDefense.Core;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Heroes.View;
using UnityEngine;

namespace Game.Heroes.View
{
    public class HeroViewSpawner : MonoBehaviour
    {
        [SerializeField]
        private BoardView boardView;

        [SerializeField]
        private HeroView heroPrefab;

        private HeroViewFactory heroViewFactory;
        private HeroViewManager heroViewManager;

        private void Awake()
        {
            heroViewFactory = new HeroViewFactory(heroPrefab);
            heroViewManager = new HeroViewManager();
        }

        private void OnEnable()
        {
            EventBus.Subscribe<HeroSummonedEvent>(OnHeroSummoned);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<HeroSummonedEvent>(OnHeroSummoned);
        }

        private void OnHeroSummoned(IEvent e)
        {
            HeroSummonedEvent evt = (HeroSummonedEvent)e;

            Hero hero = evt.Hero;

            GridCell cell =
                GameManager.Instance.Board.FindCell(hero);

            if(cell == null)
            {
                return;
            }


            CellView cellView =
                boardView.GetCellView(cell.Index);

            HeroView heroView =
                heroViewFactory.Create(
                    hero,
                    cellView.HeroContainer);

            heroViewManager.Register(
                hero,
                heroView);

            cellView.Refresh();
        }
    }
}