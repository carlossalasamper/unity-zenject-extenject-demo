using UnityEngine;
using Zenject;

namespace ZenjectDemo.Scenes.BootScene
{
    public class BootSceneInstaller : MonoInstaller
    {
        [SerializeField] protected BootScene bootScene;

        public override void InstallBindings()
        {
            Container.Bind<BootScene>().FromInstance(bootScene).AsSingle();
        }
    }
}