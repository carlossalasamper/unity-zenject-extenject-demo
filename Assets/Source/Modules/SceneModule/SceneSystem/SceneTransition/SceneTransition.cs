using System;
using UnityEngine;

namespace ZenjectDemo.Modules.SceneModule
{
    public class SceneTransition : MonoBehaviour
    {
        public Action FadeInEndAction;
        public Action FadeOutEndAction;

        private Animator animator;

        private void EmitFadeInEnd()
        {
            FadeInEndAction?.Invoke();
        }
        private void EmitFadeOutEnd()
        {
            FadeOutEndAction?.Invoke();
        }

        void Awake()
        {
            animator = gameObject.GetComponent<Animator>();
        }

        public void FadeIn()
        {
            animator.SetBool("fade-in", true);
        }

        public void OnFadeInEnd()
        {
            animator.SetBool("fade-in", false);
            EmitFadeInEnd();
        }

        public void FadeOut()
        {
            animator.SetBool("fade-out", true);
        }

        public void OnFadeOutEnd()
        {
            animator.SetBool("fade-out", false);
            EmitFadeOutEnd();
        }

        public void ClearFadeOutEndEvent()
        {
            if (FadeOutEndAction != null)
            {
                foreach (Delegate d in FadeOutEndAction.GetInvocationList())
                {
                    FadeOutEndAction -= (Action)d;
                }
            }
        }
    }
}
