using LuckyDefense.Board;
using LuckyDefense.Board.View;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Heroes.View;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Heroes.View
{
    public class HeroPresenter : MonoBehaviour
    {
        [SerializeField]
        private BoardView boardView;

        [SerializeField]
        private HeroView heroPrefab;

        private HeroViewFactory heroViewFactory;

        private void Awake()
        {
            heroViewFactory = new HeroViewFactory(heroPrefab);
        }

        private void OnEnable()
        {
            EventBus.Subscribe<HeroSummonedEvent>(OnHeroSummoned);
            EventBus.Subscribe<CellMovedEvent>(OnCellMoved);
            EventBus.Subscribe<HeroMovedEvent>(OnHeroMoved);
            EventBus.Subscribe<HeroRemovedEvent>(OnHeroRemoved);

        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<HeroSummonedEvent>(OnHeroSummoned);
            EventBus.Unsubscribe<CellMovedEvent>(OnCellMoved);
            EventBus.Unsubscribe<HeroMovedEvent>(OnHeroMoved);
            EventBus.Unsubscribe<HeroRemovedEvent>(OnHeroRemoved);
        }

        private void OnHeroSummoned(IEvent e)
        {
            HeroSummonedEvent evt = (HeroSummonedEvent)e;

            Hero hero = evt.Hero;

            GridCell cell =
                GameManager.Instance.Board.FindCell(hero);

            if (cell == null)
                return;

            CellView cellView = boardView.GetCellView(cell.Index);

            HeroView heroView = heroViewFactory.Create(hero);

            cellView.HeroStackView.AddHeroView(heroView);

            GameManager.Instance.HeroView.Add(hero, heroView);

        }

        private void OnCellMoved(IEvent e)
        {
            CellMovedEvent evt = (CellMovedEvent)e;

            RefreshCell(evt.SourceCell);

            RefreshCell(evt.TargetCell);
        }


        private void OnHeroMoved(IEvent e)
        {
            HeroMovedEvent evt = (HeroMovedEvent)e;

            HeroView heroView =
                GameManager.Instance.HeroView.GetView(evt.Hero);

            if (heroView == null)
                return;

            CellView fromCell =  boardView.GetCellView(evt.FromCell.Index);

            CellView toCell = boardView.GetCellView(evt.ToCell.Index);

            fromCell.HeroStackView.RemoveHeroView(heroView);

            toCell.HeroStackView.AddHeroView(heroView);
        }

        private void OnHeroRemoved(IEvent e)
        {
            HeroRemovedEvent evt = (HeroRemovedEvent)e;

            HeroView heroView = GameManager.Instance.HeroView.GetView(evt.Hero);

            if (heroView == null)
                return;

            CellView cellView = boardView.GetCellView(evt.Cell.Index);

            cellView.HeroStackView.RemoveHeroView(heroView);

            GameManager.Instance.HeroView.Remove(evt.Hero);
        }


        private void RefreshCell(GridCell cell)
        {
            CellView cellView = boardView.GetCellView(cell.Index);

            List<HeroView> views = new();

            foreach (Hero hero in cell.Heroes)
            {
                views.Add(GameManager.Instance.HeroView.GetView(hero));
            }

            cellView.HeroStackView.SetHeroes(views);
        }




    }
}