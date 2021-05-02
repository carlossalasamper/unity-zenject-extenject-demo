using System;
using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class PlayerFacade : MonoBehaviour, IPlayerFacade
    {
        [Inject] protected readonly GameplaySystemSettings gameplaySettings;

        [Inject] protected readonly PlayerModel model;
        [Inject] protected readonly PlayerJumpHandler jumpHandler;
        [Inject] protected readonly PlayerCollisionHandler collisionHandler;

        public Action DieAction { get; set; }

        private void Start()
        {
            Debug.Log("(PlayerFacade) Start");

            model.Position = new Vector3(transform.localPosition.x, gameplaySettings.playerInitialY, transform.localPosition.z);
            model.Scale = Vector3.one * gameplaySettings.playerScale;

            jumpHandler.Initialize();

            collisionHandler.Initialize();
            collisionHandler.ObstacleCollisionAction = OnObstacleCollision;
        }

        private void OnDestroy()
        {
            Debug.Log("(PlayerFacade) OnDestroy");

            jumpHandler.Dispose();

            collisionHandler.Dispose();
            collisionHandler.ObstacleCollisionAction = null;
        }

        private void FixedUpdate()
        {
            jumpHandler.FixedTick();
        }

        private void OnCollisionEnter(Collision collision)
        {
            collisionHandler.OnCollisionEnter(collision);
        }

        private void OnObstacleCollision()
        {
            DieAction?.Invoke();
        }
    }
}
