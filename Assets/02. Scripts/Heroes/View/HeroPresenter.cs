using Cysharp.Threading.Tasks;
using LuckyDefense.Board;
using LuckyDefense.Board.View;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using LuckyDefense.Heroes.Factory;
using LuckyDefense.Heroes.View;
using LuckyDefense.UI.Scene;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Heroes.View
{
    public class HeroPresenter : MonoBehaviour
    {
        [SerializeField]
        private BoardView boardView;

        private CellView currentView;

        private HeroViewFactory heroViewFactory;

        private void Awake()
        {
            heroViewFactory = new HeroViewFactory();
        }

        private void OnEnable()
        {
            EventBus.Subscribe<HeroSummonedEvent>(OnHeroSummoned);
            EventBus.Subscribe<CellMovedEvent>(OnCellMoved);
            EventBus.Subscribe<HeroMovedEvent>(OnHeroMoved);
            EventBus.Subscribe<HeroRemovedEvent>(OnHeroRemoved);
            EventBus.Subscribe<CellSelectedEvent>(OnCellSelected);
            EventBus.Subscribe<CellDeselectedEvent>(OnCellDeselected);

        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<HeroSummonedEvent>(OnHeroSummoned);
            EventBus.Unsubscribe<CellMovedEvent>(OnCellMoved);
            EventBus.Unsubscribe<HeroMovedEvent>(OnHeroMoved);
            EventBus.Unsubscribe<HeroRemovedEvent>(OnHeroRemoved);
            EventBus.Unsubscribe<CellSelectedEvent>(OnCellSelected);
            EventBus.Unsubscribe<CellDeselectedEvent>(OnCellDeselected);
        }

        private void OnHeroSummoned(IEvent e)
        {
            SpawnAsync((HeroSummonedEvent)e).Forget();
        }


        private async UniTaskVoid SpawnAsync(HeroSummonedEvent evt)
        {

            Hero hero = evt.Hero;

            GridCell cell =
                GameManager.Instance.Board.FindCell(hero);

            if (cell == null)
                return;

            CellView cellView = boardView.GetCellView(cell.Index);

            HeroView heroView = await heroViewFactory.Create(hero);

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

            CellView fromCell = boardView.GetCellView(evt.FromCell.Index);

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

            GameManager.Instance.Pool.Release(heroView.gameObject);
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


        private void OnCellSelected(IEvent e)
        {
            CellSelectedEvent evt = (CellSelectedEvent)e;

            // 이전 선택 해제
            if (currentView != null)
            {
                currentView.SelectionView.Hide();
            }

            currentView = boardView.GetCellView(evt.Cell.Index);

            if (currentView != null)
            {
                ShowSelectionUI(evt.Cell).Forget();

                currentView.SelectionView.Show();
            }

        }

        private void OnCellDeselected(IEvent e)
        {
            if (currentView == null)
                return;

            GameManager.Instance.UI.Get<SelectionUI>().Hide();
            currentView.SelectionView.Hide();
            currentView = null;
        }


        private async UniTask ShowSelectionUI(GridCell cell)
        {
            var scene = await  GameManager.Instance.UI.ShowScene<SelectionUI>();

            bool canMerge = GameManager.Instance.Merge.HeroMergeService.CanMerge(cell);
            bool canSell = GameManager.Instance.HeroSell.CanSell(cell);

            scene.RefreshHero(cell.Heroes[0]);

            scene.SetMergeVisible(canMerge);
            scene.SetSellVisible(canSell);
        }

    }
}