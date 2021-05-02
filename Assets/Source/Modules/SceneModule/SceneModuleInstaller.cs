using Zenject;

namespace ZenjectDemo.Modules.SceneModule {
    public class SceneModuleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SceneSystem>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}
