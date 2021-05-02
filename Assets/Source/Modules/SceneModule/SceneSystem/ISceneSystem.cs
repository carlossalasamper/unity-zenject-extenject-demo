using System;

namespace ZenjectDemo.Modules.SceneModule {
    public interface ISceneSystem
    {
        Action FadeInEndAction { get; set; }
        Action FadeOutEndAction { get; set; }

        bool IsChangingScene {get;}

        void FadeIn();
        void FadeOut(string sceneName);
    }
}