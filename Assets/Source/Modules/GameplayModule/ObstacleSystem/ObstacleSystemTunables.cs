using System;
using UnityEngine;

namespace ZenjectDemo.Modules.GameplayModule
{
    [Serializable]
    public class ObstacleSystemTunables
    {
        public Transform spawnPoint;
        public Transform despawnPoint;
        public Transform obstaclesContainer;
        public ObstacleFacade[] obstaclePrefabs;
        public int initialCopiesPerPrefab = 3;
        public float timeBetweenObstacles = 5.0f;
    }
}
