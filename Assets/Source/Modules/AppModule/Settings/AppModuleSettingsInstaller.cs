using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.AppModule
{
    [CreateAssetMenu(fileName = "AppModuleSettingsInstaller", menuName = "Installers/AppModuleSettingsInstaller")]
    public class AppModuleSettingsInstaller : ScriptableObjectInstaller<AppModuleSettingsInstaller>
    {
        public AppModuleSettings settings;

        public override void InstallBindings()
        {
            Container.BindInstances(settings);
        }
    }
}
