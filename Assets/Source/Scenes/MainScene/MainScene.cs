using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ZenjectDemo.Modules.SceneModule;

namespace ZenjectDemo.Scenes.MainScene {
    public class MainScene : MonoBehaviour
    {
        [Inject] protected readonly ISceneSystem sceneSystem;

        [SerializeField] protected Button goToMenuButton;

        private void Start()
        {
            Debug.Log("(MainScene) Start");

            goToMenuButton.onClick.AddListener(OnGoToMenuButtonClicked);

            sceneSystem.FadeIn();
        }

        private void OnDestroy()
        {
            Debug.Log("(MainScene) OnDestroy");

            goToMenuButton.onClick.RemoveAllListeners();
        }

        private void OnGoToMenuButtonClicked() {
            sceneSystem.FadeOut("MenuScene");
        }
    }
}

