using System.Collections.Generic;
using Player.Skins;
using SaveData;
using UnityEngine;

namespace UI
{
    public class ShopSkin : MonoBehaviour
    {
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private List<ItemSkin> _itemSkinPrefab;
        [SerializeField] private List<SkinView> _skinViews;
        [SerializeField] private SaveAndLoadSkinSkills _saveAndSkin;
        [SerializeField] private ItemSkin _currentItemSkin;

        private int currentCostOfGold;
        private int _currentMoney;
        private bool _isStarted;
        private bool _isFirstStartGame;

        private void Start()
        {
            for (int i = 0; i < _itemSkinPrefab.Count; i++)
            {
                _skinViews[i].Initialize(_itemSkinPrefab[i]);
            }

            // foreach (ItemSkin item in _itemSkinPrefab)
            // {
            //     item.IsBuySkin = saveAndSkin.ReadBuy(item.name);
            //     item.SelectedSkin = saveAndSkin.ReadSelect(item.name);
            // }

            _isStarted = true;
            OnEnable();
        }

        private void Update()
        {
            _currentMoney = _playerMoney.CurrentMoney;
        }

        private void OnEnable()
        {
            if (_isStarted == false)
                return;

            foreach (var view in _skinViews)
            {
                view.SellButtonClick += TrySellBuy;
                view.SelectButtonClick += SelectSkin;
            }

            ChangeActiveState();
        }

        private void OnDisable()
        {
            foreach (var view in _skinViews)
            {
                view.SellButtonClick -= TrySellBuy;
                view.SelectButtonClick -= SelectSkin;
            }
        }

        public void SaveSkinMaterial()
        {
            _saveAndSkin.SaveBuyData(_currentItemSkin.name, _currentItemSkin.IsBuySkin, _currentItemSkin.SelectedSkin);
            _saveAndSkin.ChangeSelectedSkin(_currentItemSkin.name);
        }

        private void ChangeActiveState()
        {
            DefaultMaterial();
            
            for (int i = 0; i < _itemSkinPrefab.Count; i++)
            {
                _skinViews[i].NoActiveSkin();

                if (_itemSkinPrefab[i].IsBuySkin == true)
                {
                    _skinViews[i].BuyNoActive();
                }

                if (_itemSkinPrefab[i].SelectedSkin != true) continue;
                _skinViews[i].ActiveSkin();
                _currentItemSkin = _itemSkinPrefab[i];
            }
        }

        private void SelectSkin(ItemSkin item, SkinView view)
        {
            if (item.IsBuySkin == true)
            {
                RemoveSelected();
                view.ActiveSkin();
                item.SelectSkin();
            }

            _currentItemSkin = item;
            _saveAndSkin.ChangeSelectedSkin(item.name);
        }

        private void TrySellBuy(ItemSkin item, SkinView view)
        {
            currentCostOfGold = item.Price;

            if (_currentMoney <= 0)
                return;

            if (item.IsBuySkin == true)
            {
                return;
            }

            if (currentCostOfGold <= _currentMoney)
            {
                _playerMoney.BuySkins(item);
                RemoveSelected();
                view.ActiveSkin();
                item.SelectSkin();
                _currentItemSkin = item;
            }
            
            _saveAndSkin.SaveBuyData(item.name, item.IsBuySkin, item.SelectedSkin);
        }

        private void DefaultMaterial()
        {
            _currentItemSkin.ChangeStatusBuySkin();
            _isFirstStartGame = _saveAndSkin.FirstStarLevel();
            
            if (_isFirstStartGame)
            {
                _currentItemSkin.SelectSkin();
                _isFirstStartGame = false;
                _saveAndSkin.SaveFirstStarLevel(_isFirstStartGame);
            }
        }

        private void RemoveSelected()
        {
            _currentItemSkin.UnSelectedSkin();

            foreach (var view in _skinViews)
            {
                view.NoActiveSkin();
            }
        }
    }
}