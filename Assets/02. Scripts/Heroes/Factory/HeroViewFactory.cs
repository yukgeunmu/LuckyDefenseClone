using Cysharp.Threading.Tasks;
using LuckyDefense.Core.Manager;
using LuckyDefense.Heroes.View;

namespace LuckyDefense.Heroes.Factory
{
    public class HeroViewFactory
    {

        public HeroViewFactory()
        {
        }

        public async UniTask<HeroView> Create(Hero hero)
        {
            HeroView view = await GameManager.Instance.Pool.Get<HeroView>(hero.Data.ViewPrefab);

            view.Init(hero);

            return view;
        }
    }
}