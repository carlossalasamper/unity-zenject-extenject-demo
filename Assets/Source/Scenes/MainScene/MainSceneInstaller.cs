using UnityEngine;
using Zenject;

namespace ZenjectDemo.Scenes.MainScene {
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] protected MainScene mainScene;

        public override void InstallBindings()
        {
            Container.Bind<MainScene>().FromInstance(mainScene).AsSingle();
        }
    }
}
