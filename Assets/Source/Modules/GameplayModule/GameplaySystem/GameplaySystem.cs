using System;
using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class GameplaySystem : MonoBehaviour, IGameplaySystem
    {
        [Inject] protected readonly IScoreService scoreService;
        [Inject] protected readonly IObstacleSystem obstacleSystem;
        [Inject] protected readonly IPlayerFacade player;

        public Action<int> ScoreChangeAction { get; set; }
        public Action PlayerDieAction { get; set; }

        public bool Initialized { get; private set; }
        public bool Paused { get; private set; }
        public int Score { get => scoreService.Score; }

        private void Start()
        {
            Debug.Log("(GameplaySystem) Start");

            scoreService.Initialize();
            scoreService.ScoreChangeAction = OnScoreChanged;

            player.DieAction = OnPlayerDied;
        }

        private void OnDestroy()
        {
            Debug.Log("(GameplaySystem) OnDestroy");

            scoreService.Dispose();
            scoreService.ScoreChangeAction = null;

            player.DieAction = null;
        }

        private void Update()
        {
            if (Initialized && !Paused)
            {
                scoreService.Tick();
                obstacleSystem.Tick();
            }
        }

        public void InitializeGame()
        {
            Debug.Log("(GameplaySystem) InitializeGame");
            Initialized = true;
        }

        public void PauseGame()
        {
            Debug.Log("(GameplaySystem) PauseGame");
            Paused = true;
        }

        public void ResumeGame()
        {
            Debug.Log("(GameplaySystem) ResumeGame");
            Paused = false;
        }

        private void OnScoreChanged(int score)
        {
            ScoreChangeAction?.Invoke(score);
        }
        
        private void OnPlayerDied() {
            PlayerDieAction?.Invoke();
        }
    }
}
