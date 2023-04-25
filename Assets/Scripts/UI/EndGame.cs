using System;
using UnityEngine;

namespace UI
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private Transform _panelEndGame;

        private void Start()
        {
            _panelEndGame.gameObject.SetActive(false);
        }

        public void OpenPanel()
        {
            _panelEndGame.gameObject.SetActive(true);
        }
    }
}