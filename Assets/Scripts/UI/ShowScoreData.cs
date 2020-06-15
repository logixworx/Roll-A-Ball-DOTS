using Data;
using Zenject;

namespace UI
{
    public class ShowScoreData : ShowValueData<ScoreData>
    {
        private ValueData valueData;

        [Inject]
        // ReSharper disable once ParameterHidesMember
        private void Construct(ValueData valueData)
        {
            this.valueData = valueData;
        }
        
        public override void Show()
        {
            Text.text = $"Score : {valueData}";
        }
    }
}