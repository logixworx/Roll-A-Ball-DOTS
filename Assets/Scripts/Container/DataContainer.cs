using Data;
using UnityEngine;
using Zenject;

namespace Container
{
    public class DataContainer : MonoBehaviour
    {
        public static DataContainer Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public ValueData Score => score;

        [Inject]
        private void ConstructScore(ValueData scoreData) => score = scoreData;
        
        private ValueData score;
    }
}
