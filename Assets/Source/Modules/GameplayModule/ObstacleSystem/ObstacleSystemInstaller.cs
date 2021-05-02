using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class ObstacleSystemInstaller : MonoInstaller
    {
        [SerializeField] protected ObstacleSystemTunables tunables;

        public override void InstallBindings()
        {
            Container.Bind<ObstacleSystemTunables>().FromInstance(tunables).AsSingle();

            foreach (ObstacleFacade prefab in tunables.obstaclePrefabs)
            {
                Container.BindFactory<Transform, Transform, ObstacleFacade, ObstacleFacade.Factory>()
                    .FromMonoPoolableMemoryPool(x => x.WithInitialSize(tunables.initialCopiesPerPrefab).FromComponentInNewPrefab(prefab).UnderTransform(tunables.obstaclesContainer))
                    .WhenInjectedInto<MultiObstacleFactory>();
            }
            Container.BindFactory<Transform, Transform, ObstacleFacade, ObstacleFacade.Factory>().FromFactory<MultiObstacleFactory>();
        }
    }
}
