using System;
using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class ObstacleMovementHandler : IInitializable, IDisposable, IFixedTickable, ILateTickable
    {
        [Inject] protected readonly ObstacleModel model;

        public Action DespawnPointReachedAction { get; set; }

        private Transform spawnPoint;
        private Transform despawnPoint;

        public void Initialize() { }

        public void Dispose() { }

        public void FixedTick()
        {
            model.ObstacleTransform.Translate(Time.deltaTime * model.MovementVelocity, 0, 0, Space.World);
        }

        public void LateTick()
        {
            if (model.Position.x <= despawnPoint.position.x)
            {
                DespawnPointReachedAction?.Invoke();
            }
        }

        public void Setup(Transform spawnPoint, Transform despawnPoint)
        {
            this.spawnPoint = spawnPoint;
            this.despawnPoint = despawnPoint;
        }

        public void Reset() {
            model.Position = spawnPoint.position;
        }
    }
}
