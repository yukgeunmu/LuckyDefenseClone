using LuckyDefense.Core.Events;
using LuckyDefense.Heroes.Runtime;
using System.Collections.Generic;
using UnityEngine;


namespace LuckyDefense.Core.Service
{
    public class OrbitService
    {
        private readonly List<OrbitController> controllers = new();

        public void Spawn(OrbitController controller)
        {
            controllers.Add(controller);

            foreach (var orbit in controller.Orbit)
            {
                EventBus.Publish(new OrbitSpawnedEvent(orbit));
            }

        }

        public void Update()
        {
            List<OrbitController> remove = new();

            foreach (var controller in controllers)
            {
                controller.ElapsedTime += Time.deltaTime;

                foreach (var orbit in controller.Orbit)
                {
                    orbit.Angle += controller.RotateSpeed * Time.deltaTime;
                }

                if (controller.IsFinished)
                    remove.Add(controller);
            }

            foreach (var controller in remove)
            {
                foreach (var orbit in controller.Orbit)
                {
                    EventBus.Publish(new OrbitDestroyedEvent(orbit));
                }

                controllers.Remove(controller);
            }

        }



    }
}

