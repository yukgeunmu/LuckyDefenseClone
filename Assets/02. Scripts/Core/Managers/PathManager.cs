using System.Collections.Generic;
using UnityEngine;

namespace LuckyDefense.Core.Manager
{
    public class PathManager
    {
        private readonly List<Transform> points = new();
        public int Count => points.Count;

        public IReadOnlyList<Transform> Points => points;

        public void Initialize(Transform pathRoot)
        {
            points.Clear();

            for (int i = 0; i < pathRoot.childCount;i++)
            {
                points.Add(pathRoot.GetChild(i));
            }
        }

        public Transform GetPoint(int index)
        {
            if (index < 0 ||index >= points.Count)
                return null;

            return points[index];
        }

        public Transform GetStartPoint()
        {
            return GetPoint(0);
        }

        public Transform GetGoalPoint()
        {
            return GetPoint(points.Count - 1);
        }

        public void DrawGizmos()
        {
            Gizmos.color = Color.green;

            for (int i = 0; i < points.Count - 1; i++)
            {
                Gizmos.DrawLine(points[i].position, points[i + 1].position);
            }

            Gizmos.DrawLine(points[0].position, points[points.Count - 1].position);
        }

    }
}