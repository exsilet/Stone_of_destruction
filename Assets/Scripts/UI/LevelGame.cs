using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelGame : MonoBehaviour
    {
        public void StartLevelGame(int scaneId)
        {
            SceneManager.LoadScene(scaneId);
        }
    }
}