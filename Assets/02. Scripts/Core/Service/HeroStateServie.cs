using LuckyDefense.Core.Manager;

namespace LuckyDefense.Core.Service
{
    public class HeroStateServie
    {
        public void Update()
        {
            foreach (var cell in GameManager.Instance.Board.Cells)
            {
                foreach (var hero in cell.Heroes)
                {
                    hero.Update();
                }
            }
        }
    }
}