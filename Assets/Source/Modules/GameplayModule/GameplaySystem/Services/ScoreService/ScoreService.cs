using System;
using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class ScoreService : IScoreService
    {
        [Inject] protected readonly GameplaySystemSettings settings;

        public Action<int> ScoreChangeAction { get; set; }

        public int Score { get; private set; }

        public void Initialize()
        {
            Debug.Log("(ScoreService) Initialize");

            Reset();
        }

        public void Dispose()
        {
            Debug.Log("(ScoreService) Dispose");
        }

        public void Tick()
        {
            Score += Mathf.FloorToInt(Time.deltaTime * settings.scorePerDeltaTime);
            ScoreChangeAction?.Invoke(Score);
        }

        public void Reset()
        {
            Score = 0;
        }
    }
}
