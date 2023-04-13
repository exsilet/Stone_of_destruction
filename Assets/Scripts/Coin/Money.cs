using System.Collections.Generic;
using SaveData;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private CoinText _coinText;
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private SaveAndLoadSkinSkills andLoadSkinSkills;
    [SerializeField] private Skill _moneySkill;
    [SerializeField] private List<Skill> _skillPrefabs;

    private int _moneyLevelSkill;

    private void Start()
    {
        foreach (var skill in _skillPrefabs)
        {
            if (_moneySkill.Label == skill.Label)
            {
                _moneyLevelSkill = andLoadSkinSkills.ReadStarData(skill.Label);
                CoinMultiplier();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMoney player))
        {
            _explosionParticle.Play();
            _coinText.RaiseACoin(_money);
            player.IncreaseMoney(_money);
            player.IncreaseMoneyLevel(_money);
            Destroy(gameObject, 0.2f);
        }
    }

    private void CoinMultiplier()
    {
        if (_moneyLevelSkill > 0) 
            _money = (int)(((_moneyLevelSkill * 0.2f) * _money) + _money);
    }
}
