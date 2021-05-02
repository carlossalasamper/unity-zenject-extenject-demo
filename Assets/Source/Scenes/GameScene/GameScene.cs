using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;
using ZenjectDemo.Modules.GameplayModule;
using ZenjectDemo.Modules.SceneModule;

namespace ZenjectDemo.Scenes.GameScene
{
    public class GameScene : MonoBehaviour
    {
        [Inject] protected readonly GameplayModuleSettings gameplaySettings;
        [Inject] protected readonly IGameplaySystem gameplaySystem;
        [Inject] protected readonly ISceneSystem sceneSystem;

        [SerializeField] protected Text scoreLabel;

        private void Start()
        {
            Debug.Log("(GameScene) Start");

            gameplaySystem.ScoreChangeAction = OnScoreChanged;
            gameplaySystem.PlayerDieAction = OnPlayerDied;

            sceneSystem.FadeInEndAction = gameplaySystem.InitializeGame;
            sceneSystem.FadeIn();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                sceneSystem.FadeOut("MenuScene");
            }
        }

        private void OnDestroy()
        {
            Debug.Log("(GameScene) OnDestroy");

            gameplaySystem.ScoreChangeAction = null;
            gameplaySystem.PlayerDieAction = null;
        }

        private void OnScoreChanged(int score)
        {
            scoreLabel.text = score.ToString(gameplaySettings.scoreFormat);
        }

        private void OnPlayerDied()
        {
            ReloadScene();
        }

        private void ReloadScene() {
            SceneManager.LoadScene("GameScene");
        }
    }
}