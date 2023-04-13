using UnityEngine;

namespace UI
{
    public class PanelMenu : MonoBehaviour
    {
        [SerializeField] private Transform _openPanelMenu;

        private bool isEnabled = false;

        public void ButtonClick()
        {
            isEnabled = isEnabled == false;

            _openPanelMenu.gameObject.SetActive(isEnabled);
        }
    }
}