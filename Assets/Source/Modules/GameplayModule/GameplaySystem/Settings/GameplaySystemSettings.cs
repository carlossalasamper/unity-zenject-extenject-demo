using System;

namespace ZenjectDemo.Modules.GameplayModule
{
    [Serializable]
    public class GameplaySystemSettings
    {
        public float playerScale = 1.0f;
        public float playerInitialY = 15.0f;
        public float scorePerDeltaTime = 50.0f;
    }
}
