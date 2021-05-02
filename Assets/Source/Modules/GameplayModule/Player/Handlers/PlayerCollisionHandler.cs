using System;
using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class PlayerCollisionHandler : IInitializable, IDisposable
    {
        [Inject] protected readonly PlayerModel model;

        public Action ObstacleCollisionAction { get; set; }

        public void Initialize() { }

        public void Dispose() { }

        public void OnCollisionEnter(Collision collision)
        {
            switch (collision.gameObject.tag)
            {
                case "floor":
                    {
                        model.IsGrounded = true;
                        break;
                    }
                case "obstacle":
                    {
                        ObstacleCollisionAction?.Invoke();
                        break;
                    }
            }
        }
    }
}
