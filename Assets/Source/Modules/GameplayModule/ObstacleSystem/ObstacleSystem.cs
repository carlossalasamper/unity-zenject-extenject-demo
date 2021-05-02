using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class ObstacleSystem : MonoBehaviour, IObstacleSystem
    {
        [Inject] protected readonly ObstacleSystemTunables tunables;
        [Inject] protected readonly ObstacleFacade.Factory obstacleFactory;

        private float timeToNextObstacle;

        public void Tick()
        {
            timeToNextObstacle -= Time.deltaTime;

            if (timeToNextObstacle <= 0.0f)
            {
                SpawnObstacle();
                timeToNextObstacle = tunables.timeBetweenObstacles;
            }
        }

        private void Start()
        {
            Debug.Log("(ObstacleSystem) Start");

            timeToNextObstacle = tunables.timeBetweenObstacles;
        }

        private void OnDestroy()
        {
            Debug.Log("(ObstacleSystem) OnDestroy");
        }

        public void SpawnObstacle()
        {
            obstacleFactory.Create(tunables.spawnPoint, tunables.despawnPoint);
        }
    }
}
