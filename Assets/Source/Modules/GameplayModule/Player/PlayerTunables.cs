using System;
using UnityEngine;

namespace ZenjectDemo.Modules.GameplayModule
{
    [Serializable]
    public class PlayerTunables
    {
        public Rigidbody rigidbody;
        public MeshRenderer meshRenderer;
        public float jumpVelocity = 8.0f;
    }
}
