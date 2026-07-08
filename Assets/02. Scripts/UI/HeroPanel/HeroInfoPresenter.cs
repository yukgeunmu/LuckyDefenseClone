using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using UnityEngine;


namespace LuckyDefense.UI.HeroPanel
{
    public class HeroInfoPresenter : MonoBehaviour
    {
        [SerializeField]
        private HeroInfoView view;

        private void OnEnable()
        {
            EventBus.Subscribe<CellSelectedEvent>(OnSelected);
            EventBus.Subscribe<CellDeselectedEvent>(OnDeselected);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe<CellSelectedEvent>(OnSelected);
            EventBus.Unsubscribe<CellDeselectedEvent>(OnDeselected);
        }

        private void OnSelected(IEvent e)
        {
            Hero hero =
                GameManager.Instance
                    .CellSelection
                    .SelectedHero;

            if (hero == null)
            {
                view.Hide();
                return;
            }

            view.Refresh(hero);
            view.Show();
        }

        private void OnDeselected(IEvent e)
        {
            view.Hide();
        }
    }
}


