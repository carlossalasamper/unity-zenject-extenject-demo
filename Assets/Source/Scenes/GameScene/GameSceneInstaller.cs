using UnityEngine;
using Zenject;

namespace ZenjectDemo.Scenes.GameScene {
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] protected GameScene gameScene;

        public override void InstallBindings()
        {
            Container.Bind<GameScene>().FromInstance(gameScene).AsSingle();
        }
    }
}
