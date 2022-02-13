using UnityEngine;

namespace Make_Way_Jump
{
    public class HeroInitializer
    {
        [SerializeField] private HeroData _heroData;
        
        public HeroInitializer(HeroData heroData)
        {
            _heroData = heroData;
        }

        public void Initialize()
        {
            Object.Instantiate(_heroData.HeroObject);
        }
    }
}