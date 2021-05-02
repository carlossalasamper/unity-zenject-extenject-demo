using System;
using UnityEngine;
using Zenject;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class PlayerJumpHandler : IInitializable, IDisposable, IFixedTickable
    {
        [Inject] protected readonly PlayerModel model;

        public void Initialize() { }

        public void Dispose() { }

        public void FixedTick()
        {
            if (Input.GetKeyDown(KeyCode.Space) && model.IsGrounded)
            {
                model.Velocity = new Vector3(0, model.JumpVelocity, 0);
                model.IsGrounded = false;
            }
        }
    }
}
