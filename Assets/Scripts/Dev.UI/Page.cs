using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dev.UI
{
    public class Page : MonoBehaviour
    {
        protected virtual void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}