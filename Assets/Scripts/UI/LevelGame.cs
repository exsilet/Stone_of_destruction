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

            CloseLevels();
            OpenLevels();
        }

        private void OpenLevels()
        {
            for (int i = 0; i < _levelUnLock - 1; i++)
            {
                if (i + 2 >= SceneManager.sceneCountInBuildSettings)
                    return;

                _levels[i].enabled = true;
                _levels[i].gameObject.GetComponent<UnLockLevel>().LevelName.gameObject.SetActive(true);
                _levels[i].gameObject.GetComponent<UnLockLevel>().LevelUnlock.gameObject.SetActive(false);
            }
        }

        private void CloseLevels()
        {
            foreach (var level in _levels)
            {
                level.enabled = false;
                level.gameObject.GetComponent<UnLockLevel>().LevelName.gameObject.SetActive(false);
                level.gameObject.GetComponent<UnLockLevel>().LevelUnlock.gameObject.SetActive(true);
            }
        }

        public void StartLevelGame(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }
    }
}