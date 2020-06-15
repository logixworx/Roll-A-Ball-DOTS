using Container;
using Data;
using Tags;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Systems
{
    [AlwaysSynchronizeSystem]
    [UpdateAfter(typeof(CollectSystem))]
    public class DeleteEntitySystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            
            Entities.WithAll<DeleteTag>().ForEach((Entity entity) =>
            {
                DataContainer.Instance.Score.Value += 1;
                // ReSharper disable once AccessToDisposedClosure
                entityCommandBuffer.DestroyEntity(entity);
            }).WithoutBurst().Run();
            
            entityCommandBuffer.Playback(EntityManager);
            entityCommandBuffer.Dispose();

            return default;
        }
    }
}