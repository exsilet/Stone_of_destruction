using System.Collections.Generic;
using SaveData;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LevelGame : MonoBehaviour
    {
        [SerializeField] private List<Button> _levels = new();
        [SerializeField] private SaveLoadeLevels _loadeLevels;

        private int _levelUnLock;
        
        private void Start()
        {
            _levelUnLock = _loadeLevels.ReadLevel();
            
            for (int i = 0; i < _levels.Count; i++)
            {
                _levels[i].enabled = false;
                _levels[i].gameObject.GetComponent<UnLockLevel>().LevelName.gameObject.SetActive(false);
                _levels[i].gameObject.GetComponent<UnLockLevel>().LevelUnlock.gameObject.SetActive(true);
            }

            for (int i = 0; i < _levelUnLock-2; i++)
            {
                _levels[i].enabled = true;
                _levels[i].gameObject.GetComponent<UnLockLevel>().LevelName.gameObject.SetActive(true);
                _levels[i].gameObject.GetComponent<UnLockLevel>().LevelUnlock.gameObject.SetActive(false);
            }
        }

        public void StartLevelGame(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }
    }
}