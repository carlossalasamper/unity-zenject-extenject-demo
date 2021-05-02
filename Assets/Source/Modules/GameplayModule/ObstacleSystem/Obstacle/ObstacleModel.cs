using UnityEngine;

namespace ZenjectDemo.Modules.GameplayModule
{
    public class ObstacleModel
    {
        private readonly MeshRenderer meshRenderer;
        private readonly float movementVelocity;

        public ObstacleModel(
            MeshRenderer meshRenderer,
            float movementVelocity
        )
        {
            this.meshRenderer = meshRenderer;
            this.movementVelocity = movementVelocity;
        }

        public Transform ObstacleTransform {
            get => meshRenderer.transform;
        }

        public MeshRenderer Renderer
        {
            get { return meshRenderer; }
        }

        public Vector3 Scale
        {
            get { return ObstacleTransform.localScale; }
            set { ObstacleTransform.localScale = value; }
        }

        public Quaternion Rotation
        {
            get { return ObstacleTransform.rotation; }
            set { ObstacleTransform.rotation = value; }
        }

        public Vector3 Position
        {
            get { return ObstacleTransform.position; }
            set { ObstacleTransform.position = value; }
        }

        public float MovementVelocity
        {
            get { return movementVelocity; }
        }
    }
}
