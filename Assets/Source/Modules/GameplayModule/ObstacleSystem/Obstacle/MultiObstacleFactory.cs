using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule {
    public class MultiObstacleFactory : IFactory<Transform, Transform, ObstacleFacade>
    {
        [Inject] protected readonly List<ObstacleFacade.Factory> subFactories;

        public ObstacleFacade Create(Transform spawnPoint, Transform despawnPoint)
        {
            int obstacleType = Random.Range(0, subFactories.Count - 1);

            return subFactories[obstacleType].Create(spawnPoint, despawnPoint);
        }
    }
}
