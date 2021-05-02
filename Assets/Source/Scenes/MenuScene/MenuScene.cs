using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ZenjectDemo.Modules.SceneModule;

namespace ZenjectDemo.Scenes.MenuScene {
    public class MenuScene : MonoBehaviour
    {
        [Inject] protected readonly ISceneSystem sceneSystem;

        [SerializeField] protected Button goToGameButton;

        private void Start()
        {
            Debug.Log("(MenuScene) Start");

            goToGameButton.onClick.AddListener(OnGoToGameButtonClicked);

            sceneSystem.FadeIn();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                sceneSystem.FadeOut("MainScene");
            }
        }

        private void OnDestroy()
        {
            Debug.Log("(MenuScene) OnDestroy");

            goToGameButton.onClick.RemoveAllListeners();
        }

        private void OnGoToGameButtonClicked() {
            sceneSystem.FadeOut("GameScene");
        }
    }

}
