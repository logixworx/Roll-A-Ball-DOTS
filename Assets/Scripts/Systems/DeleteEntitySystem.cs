using Tags;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

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
                // ReSharper disable once AccessToDisposedClosure
                entityCommandBuffer.DestroyEntity(entity);
            }).Run();
            
            entityCommandBuffer.Playback(EntityManager);
            entityCommandBuffer.Dispose();

            return default;
        }
    }
}