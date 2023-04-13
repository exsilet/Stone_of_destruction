using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Player.Skins
{
    public class SkinView : MonoBehaviour
    {
        [SerializeField] private Image _itemSkinColor;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Transform _iconPrice;
        [SerializeField] private TMP_Text _sellText;
        [SerializeField] private TMP_Text _buyText;
        [SerializeField] private TMP_Text _selectedText;
        [SerializeField] private Button _sellButton;
        [SerializeField] private Button _activeSkinButton;

        private ItemSkin _item;

        public event UnityAction<ItemSkin, SkinView> SellButtonClick;
        public event UnityAction<ItemSkin, SkinView> SelectButtonClick;
        
        public void Initialize(ItemSkin itemSkin)
        {
            _item = itemSkin;
            _icon.sprite = itemSkin.Sprite;
            _price.text = itemSkin.Price.ToString();
        }

        public void TryOnclick()
        {
            SellButtonClick?.Invoke(_item, this);
        }

        public void SelectSkin()
        {
            SelectButtonClick?.Invoke(_item, this);
        }

        public void ActiveSkin()
        {
            _item.ChangeStatusBuySkin();
            _sellButton.gameObject.SetActive(false);
            _iconPrice.gameObject.SetActive(false);
            _sellText.gameObject.SetActive(false);
            _activeSkinButton.gameObject.SetActive(true);
            _buyText.gameObject.SetActive(false);
            _selectedText.gameObject.SetActive(true);
            _itemSkinColor.color = new Color(0.87f,0.92f,0.51f,1);
        }

        public void NoActiveSkin()
        {
            _buyText.gameObject.SetActive(true);
            _selectedText.gameObject.SetActive(false);
            _itemSkinColor.color = Color.white;
        }

        public void BuyNoActive()
        {
            _sellButton.gameObject.SetActive(false);
            _iconPrice.gameObject.SetActive(false);
            _selectedText.gameObject.SetActive(false);
            _activeSkinButton.gameObject.SetActive(true);
            _buyText.gameObject.SetActive(true);
        }
    }
}