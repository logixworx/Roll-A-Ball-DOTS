using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Score", menuName = "Data/Score", order = 0)]
    public class ScoreData : ValueData
    {
        public override string Display()
        {
            return ((int) Value).ToString();
        }
    }
}