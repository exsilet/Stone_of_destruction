using System;

namespace SaveData
{
    [Serializable]
    public class SkinData
    {
        public string NameSkin;
        public bool IsBuySkin;
        public bool SelectedBuy;

        public SkinData(string nameSkin, bool isBuySkin, bool selectedBuy)
        {
            NameSkin = nameSkin;
            IsBuySkin = isBuySkin;
            SelectedBuy = selectedBuy;
        }
    }
}