using System;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public interface IScoreService : IInitializable, IDisposable, ITickable
    {
        Action<int> ScoreChangeAction { get; set; }
        int Score { get; }

        void Reset();
    }
}