using SaveData;
using UnityEngine;

namespace Player.Skins
{
    public class ItemSkin : MonoBehaviour
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Material _material;
        [SerializeField] private int _price;
        [SerializeField] private bool _isBuySkin;
        [SerializeField] private bool _selected;
        [SerializeField] private SaveAndLoadSkinSkills saveAndLoadSkin;

        public Sprite Sprite => _sprite;
        public Material Material => _material;
        public int Price => _price;
        public bool SelectedSkin => _selected;
        public bool IsBuySkin => _isBuySkin;

        private void Start()
        {
            _selected = saveAndLoadSkin.ReadSelect(this.name);
            _isBuySkin = saveAndLoadSkin.ReadBuy(this.name);
        }

        public void ChangeStatusBuySkin()
        {
            _isBuySkin = true;
        }

        public void SelectSkin()
        {
            _selected = true;
        }

        public void UnSelectedSkin()
        {
            _selected = false;
        }
    }
}