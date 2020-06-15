using Data;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class ShowValueData<T> : MonoBehaviour where T : ValueData
    {
        protected TextMeshProUGUI Text;

        private void OnValidate()
        {
            Text = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            Show();
        }

        public abstract void Show();
    }
}