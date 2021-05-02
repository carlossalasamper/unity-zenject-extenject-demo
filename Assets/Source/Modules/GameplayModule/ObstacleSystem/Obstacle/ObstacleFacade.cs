using System;
using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class ObstacleFacade : MonoBehaviour, IPoolable<Transform, Transform, IMemoryPool>
    {
        [Inject] protected readonly ObstacleModel model;
        [Inject] protected readonly ObstacleMovementHandler movementHandler;

        private IMemoryPool pool;
        private Transform spawnPoint;
        private Transform despawnPoint;

        public void OnSpawned(Transform spawnPoint, Transform despawnPoint, IMemoryPool pool)
        {
            this.spawnPoint = spawnPoint;
            this.despawnPoint = despawnPoint;
            this.pool = pool;

            movementHandler.Setup(spawnPoint, despawnPoint);
            Reset();
        }

        public void OnDespawned()
        {
            spawnPoint = null;
            despawnPoint = null;
            pool = null;
        }

        public void Despawn()
        {
            pool.Despawn(this);
        }

        public void Reset()
        {
            movementHandler.Reset();            
        }

        private void Start()
        {
            movementHandler.Initialize();
            movementHandler.DespawnPointReachedAction += OnDespawnPointReached;
        }

        private void FixedUpdate()
        {
            movementHandler.FixedTick();
        }

        private void LateUpdate()
        {
            movementHandler.LateTick();            
        }

        private void OnDestroy()
        {
            movementHandler.DespawnPointReachedAction = null;
            movementHandler.Dispose();
        }

        private void OnDespawnPointReached() {
            Despawn();
        }

        public class Factory : PlaceholderFactory<Transform, Transform, ObstacleFacade>
        {
        }
    }
}
