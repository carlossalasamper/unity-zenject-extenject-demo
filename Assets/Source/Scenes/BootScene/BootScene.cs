using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZenjectDemo.Scenes.BootScene {
    public class BootScene : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("(BootScene) Start");

            SceneManager.LoadScene("MainScene");
        }

        private void OnDestroy()
        {
            Debug.Log("(BootScene) OnDestroy");
        }
    }
}
