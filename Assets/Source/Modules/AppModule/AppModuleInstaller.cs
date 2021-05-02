using Zenject;

namespace ZenjectDemo.Modules.AppModule {
    public class AppModuleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AppSystem>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}
