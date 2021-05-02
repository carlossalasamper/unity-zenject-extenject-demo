using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule {
    public class GameplayModuleInstaller : MonoInstaller
    {
        [SerializeField] protected GameplaySystem gameplaySystem;

        public override void InstallBindings()
        {
            Container.Bind<IGameplaySystem>().FromInstance(gameplaySystem).AsSingle();
        }
    }
}
