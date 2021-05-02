using System;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public interface IGameplaySystem
    {
        Action<int> ScoreChangeAction { get; set; }
        Action PlayerDieAction { get; set; }

        bool Initialized { get; }
        bool Paused { get; }
        int Score { get; }

        void InitializeGame();
        void PauseGame();
        void ResumeGame();
    }
}