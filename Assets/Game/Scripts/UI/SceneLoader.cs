using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.UI
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
    }
}
