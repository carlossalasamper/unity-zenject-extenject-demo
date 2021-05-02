using System;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public interface IObstacleSystem : ITickable
    {
        void SpawnObstacle();
    }
}