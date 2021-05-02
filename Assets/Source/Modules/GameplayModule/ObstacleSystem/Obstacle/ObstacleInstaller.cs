using System;
using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class ObstacleInstaller : MonoInstaller
    {
        [SerializeField] protected ObstacleTunables tunables;

        public override void InstallBindings()
        {
            Container.Bind<ObstacleModel>().AsSingle()
                .WithArguments(tunables.meshRenderer, tunables.movementVelocity).NonLazy();

            Container.Bind<ObstacleMovementHandler>().AsSingle().NonLazy();
        }
    }
}
