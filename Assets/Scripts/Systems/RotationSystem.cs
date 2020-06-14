using Components;
using Tags;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    [AlwaysSynchronizeSystem]
    public class RotationSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;

            Entities.WithAll<CollectibleTag>().ForEach((ref Rotation rotation, in SpeedComponent speedComponent) =>
            {
                //Rotate X
                rotation.Value = math.mul(
                    rotation.Value,
                    quaternion.RotateX(math.radians(speedComponent.Value * deltaTime)));
                //Rotate Y
                rotation.Value = math.mul(
                    rotation.Value,
                    quaternion.RotateY(math.radians(speedComponent.Value * deltaTime)));
                //Rotate Z
                rotation.Value = math.mul(
                    rotation.Value,
                    quaternion.RotateZ(math.radians(speedComponent.Value * deltaTime)));
            }).Run();

            return default;
        }
    }
}