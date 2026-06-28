using System.Collections.Generic;
using UnityEngine;



namespace  LuckyDefense.Core.View
{
    public class EntityViewManager<TEntity, TView> where TView : Component
    {
        private readonly Dictionary<TEntity, TView> views = new();

        public void Add(TEntity entity, TView view)
        {
            views.Add(entity, view);
        }

        public TView GetView(TEntity entity)
        {
            views.TryGetValue( entity, out TView view);

            return view;
        }

        public void Remove(TEntity entity)
        {
            if (!views.TryGetValue(entity, out TView view))
                return;

            Object.Destroy(view.gameObject);

            views.Remove(entity);
        }
    }
}
