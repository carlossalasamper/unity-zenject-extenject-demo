using UnityEngine;
using Zenject;

namespace ZenjectDemo.Scenes.MenuScene {
    public class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField] protected MenuScene menuScene;

        public override void InstallBindings()
        {
            Container.Bind<MenuScene>().FromInstance(menuScene).AsSingle();
        }
    }
}
