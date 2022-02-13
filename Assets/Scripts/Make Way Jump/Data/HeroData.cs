using UnityEngine;

namespace Make_Way_Jump
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "MakeWayJump/HeroData", order = 0)]
    public class HeroData : ScriptableObject
    {
        [SerializeField] private GameObject _heroObject;

        public GameObject HeroObject => _heroObject;
    }
}