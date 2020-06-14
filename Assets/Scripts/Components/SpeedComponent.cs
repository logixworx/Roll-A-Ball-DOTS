using Unity.Entities;

namespace Components
{
    [GenerateAuthoringComponent]
    public struct SpeedComponent : IComponentData
    {
        // ReSharper disable once UnassignedField.Global
        public float Value;
    }
}