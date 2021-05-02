using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    [CreateAssetMenu(fileName = "GameplayModuleSettingsInstaller", menuName = "Installers/GameplayModuleSettingsInstaller")]
    public class GameplayModuleSettingsInstaller : ScriptableObjectInstaller<GameplayModuleSettingsInstaller>
    {
        public GameplayModuleSettings settings;

        public override void InstallBindings()
        {
            Container.BindInstances(settings);
        }
    }
}
