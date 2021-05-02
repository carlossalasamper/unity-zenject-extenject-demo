using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.SceneModule
{
    [CreateAssetMenu(fileName = "SceneModuleSettingsInstaller", menuName = "Installers/SceneModuleSettingsInstaller")]
    public class SceneModuleSettingsInstaller : ScriptableObjectInstaller<SceneModuleSettingsInstaller>
    {
        public SceneModuleSettings settings;

        public override void InstallBindings()
        {
            Container.BindInstances(settings);
        }
    }
}
