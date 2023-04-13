using System.Collections.Generic;
using Player.Skins;
using SaveData;
using UnityEngine;

namespace Player
{
    public class PlayerSkin : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _playerMaterial;
        [SerializeField] private Material _currentMaterial;
        [SerializeField] private SaveAndLoadSkinSkills andLoadSkinSkin;
        [SerializeField] private List<ItemSkin> _itemSkins;

        private ItemSkin _currentItemSkin;
        
        private void Start()
        {
            foreach (ItemSkin item in _itemSkins)
            {
                if (andLoadSkinSkin.ReadSelect(item.name))
                {
                    if (item.SelectedSkin == true)
                    {
                        _playerMaterial.material = item.Material;
                    }
                }
            }
        }
    }
}