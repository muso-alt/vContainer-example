using UnityEngine;

namespace Make_Way_Jump
{
    [CreateAssetMenu(fileName = "BlocksData", menuName = "MakeWayJump/BlocksData", order = 0)]
    public class BlocksData : ScriptableObject
    {
        [SerializeField] private GameObject[] _blocks;
        [SerializeField] private float _horizontalOffset = 2f;
        [SerializeField] private float _verticalOffset = 4f;

        public GameObject[] Blocks => _blocks;

        public float HorizontalOffset => _horizontalOffset;

        public float VerticalOffset => _verticalOffset;
    }
}