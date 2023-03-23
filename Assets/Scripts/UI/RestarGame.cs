using UnityEngine;
using UnityEngine.SceneManagement;

public class RestarGame : MonoBehaviour
{
    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
