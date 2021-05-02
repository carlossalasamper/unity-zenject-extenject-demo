using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    [CreateAssetMenu(fileName = "GameplaySystemSettingsInstaller", menuName = "Installers/GameplaySystemSettingsInstaller")]
    public class GameplaySystemSettingsInstaller : ScriptableObjectInstaller<GameplaySystemSettingsInstaller>
    {
        public GameplaySystemSettings settings;

        public override void InstallBindings()
        {
            Container.BindInstances(settings);
        }
    }
}
