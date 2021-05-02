using UnityEngine;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class PlayerModel
    {
        private readonly Rigidbody rigidBody;
        private readonly MeshRenderer meshRenderer;
        private readonly float jumpVelocity;

        public PlayerModel(
            Rigidbody rigidBody,
            MeshRenderer meshRenderer,
            float jumpVelocity
)
        {
            this.rigidBody = rigidBody;
            this.meshRenderer = meshRenderer;
            this.jumpVelocity = jumpVelocity;
        }

        public MeshRenderer Renderer
        {
            get { return meshRenderer; }
        }

        public Vector3 Scale
        {
            get { return rigidBody.transform.localScale; }
            set { rigidBody.transform.localScale = value; }
        }

        public Quaternion Rotation
        {
            get { return rigidBody.rotation; }
            set { rigidBody.rotation = value; }
        }

        public Vector3 Position
        {
            get { return rigidBody.position; }
            set { rigidBody.position = value; }
        }

        public float JumpVelocity
        {
            get { return jumpVelocity; }
        }

        public Vector3 Velocity
        {
            get { return rigidBody.velocity; }
            set { rigidBody.velocity = value; }
        }

        public bool IsGrounded
        {
            get; set;
        }
    }
}
