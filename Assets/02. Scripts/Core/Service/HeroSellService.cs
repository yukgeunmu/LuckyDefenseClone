using LuckyDefense.Board;
using LuckyDefense.Core.Events;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes;
using UnityEngine;



namespace LuckyDefense.Core.Service
{
    public class HeroSellService
    {
        public bool CanSell(GridCell cell)
        {
            return cell != null && cell.HeroCount > 0;
        }

        public void Sell(GridCell cell)
        {
            if (!CanSell(cell))
                return;

            Hero hero = cell.Heroes[0];

            int price = hero.Data.SellPrice;

            GameManager.Instance.Goods.AddGold(price);

            GameManager.Instance.Placement.RemoveHero(hero);

            EventBus.Publish(new HeroSoldEvent(hero));
        }
    }
}

