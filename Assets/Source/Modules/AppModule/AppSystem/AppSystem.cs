using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.AppModule
{
    public class AppSystem : MonoBehaviour, IAppSystem
    {
        [Inject] protected AppModuleSettings settings;

        private void Start()
        {
            Debug.Log("(AppSystem) Start");

            Application.targetFrameRate = settings.targetFrameRate;
        }

        private void OnDestroy()
        {
            Debug.Log("(AppSystem) OnDestroy");
        }
    }
}