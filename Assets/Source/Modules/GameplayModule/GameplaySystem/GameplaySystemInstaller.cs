using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class GameplaySystemInstaller : MonoInstaller
    {
        [SerializeField] protected ObstacleSystem obstacleSystem;
        [SerializeField] protected PlayerFacade player;

        public override void InstallBindings()
        {
            Container.Bind(typeof(IScoreService)).To<ScoreService>().AsSingle().NonLazy();
            Container.Bind<IObstacleSystem>().FromInstance(obstacleSystem).AsSingle();
            Container.Bind<IPlayerFacade>().FromInstance(player).AsSingle();
        }
    }
}
