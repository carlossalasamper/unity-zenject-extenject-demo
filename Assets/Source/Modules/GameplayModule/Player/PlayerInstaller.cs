using System;
using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] protected PlayerTunables tunables;

        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().AsSingle()
                .WithArguments(tunables.rigidbody, tunables.meshRenderer, tunables.jumpVelocity).NonLazy();

            Container.Bind<PlayerJumpHandler>().AsSingle().NonLazy();
            Container.Bind<PlayerCollisionHandler>().AsSingle().NonLazy();
        }
    }
}
