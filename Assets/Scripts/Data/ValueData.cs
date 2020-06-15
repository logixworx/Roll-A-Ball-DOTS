using UnityEngine;

namespace Data
{
    public abstract class ValueData : ScriptableObject
    {
        [SerializeField] private float value;

        public float Value
        {
            get => value;
            set => this.value = value;
        }

        public override string ToString()
        {
            return Display();
        }

        public abstract string Display();
    }
}