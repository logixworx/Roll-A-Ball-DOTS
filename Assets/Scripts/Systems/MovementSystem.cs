using Components;
using Tags;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;

namespace Systems
{
    [AlwaysSynchronizeSystem]
    public class MovementSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            var input = new float2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"));
            
            Entities.WithAll<BallTag>().ForEach((ref PhysicsVelocity physicsVelocity, in SpeedComponent speedComponent) =>
            {
                var velocity = physicsVelocity.Linear.xz;
                velocity += input * speedComponent.Value * deltaTime;
                physicsVelocity.Linear.xz = velocity;
            }).Run();

            return default;
        }
    }
}
