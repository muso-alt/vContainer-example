using UnityEngine;

namespace Pop_Items.Data
{
    [CreateAssetMenu(fileName = "PopItemsSpawnerData", menuName = "Pop Items/PopItemsSpawnerData", order = 0)]
    public class PopItemsSpawnerData : ScriptableObject
    {
        [SerializeField] private Sprite _correctAnswerSprite;
        [SerializeField] private string _finishTag = "Finish";
        
        [Header("Configurations Data")]
        [SerializeField] private float _itemsOffset = 4f;
        [SerializeField] private float _leftOffset = 5f;
        [SerializeField] private float _rightOffset = -3f;
        
        [SerializeField] private int _countOfSpawningItems = 1;
        [SerializeField] private float _spawnInterval = 1f;
        
        [SerializeField] private float _startVerticalPosition = -11f;
        [SerializeField] private float _hundredForFrequency = 101f;
        
        [SerializeField, Range(0f, 100f)] private float frequencyOfCorrectObjects;
        
        [Header("SpawningObjects")]
        [SerializeField] private GameObject[] _objects;

        public GameObject[] Objects => _objects;
        public float FrequencyOfCorrectObjects => frequencyOfCorrectObjects;
        public Sprite CorrectAnswerSprite => _correctAnswerSprite;
        public float ItemsOffset => _itemsOffset;
        public float LeftOffset => _leftOffset;
        public float RightOffset => _rightOffset;
        public int CountOfSpawningItems => _countOfSpawningItems;
        public float SpawnInterval => _spawnInterval;
        public float StartVerticalPosition => _startVerticalPosition;
        public float HundredForFrequency => _hundredForFrequency;
        public string FinishTag => _finishTag;
    }
}