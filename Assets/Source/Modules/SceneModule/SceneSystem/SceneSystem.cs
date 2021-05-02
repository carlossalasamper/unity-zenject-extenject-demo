using System;
using Zenject;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZenjectDemo.Modules.SceneModule
{
    public class SceneSystem : MonoBehaviour, ISceneSystem
    {
        [Inject] protected SceneModuleSettings settings;

        private SceneTransition transition;

        public Action FadeInEndAction { get; set; }
        public Action FadeOutEndAction { get; set; }
        public bool IsChangingScene { get; private set; }

        private void Start()
        {
            Debug.Log("(SceneSystem) Start");

            transition = Instantiate(settings.transitionPrefab, transform).GetComponent<SceneTransition>();
            transition.gameObject.SetActive(false);

            transition.FadeInEndAction += OnFadeInEnd;
        }

        private void OnDestroy()
        {
            Debug.Log("(SceneSystem) OnDestroy");

            transition = null;
        }

        public void FadeIn()
        {
            if (!IsChangingScene)
            {
                IsChangingScene = true;

                transition.gameObject.SetActive(true);
                transition.FadeIn();
            }
        }

        public void FadeOut(string sceneName)
        {
            if (!IsChangingScene)
            {
                IsChangingScene = true;

                transition.ClearFadeOutEndEvent();
                transition.FadeOutEndAction += () => OnFadeOutEnd(sceneName);
                transition.gameObject.SetActive(true);
                transition.FadeOut();
            }
        }

        private void OnFadeInEnd()
        {
            transition.gameObject.SetActive(false);
            FadeInEndAction?.Invoke();

            IsChangingScene = false;
        }

        private void OnFadeOutEnd(string scene)
        {
            ClearFadeInEndAction();
            SceneManager.LoadScene(scene);

            IsChangingScene = false;
        }

        /// <summary>
        /// Clears FadeInEndAction callbacks
        /// </summary>
        private void ClearFadeInEndAction()
        {
            if (FadeInEndAction != null)
            {
                foreach (Delegate d in FadeInEndAction.GetInvocationList())
                {
                    FadeInEndAction -= (Action)d;
                }
            }
        }
    }
}