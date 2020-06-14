using Interfaces;
using Tags;
using Unity.Collections;
using Unity.Entities;
using Unity.Physics;

namespace Jobs
{
    public struct OnTriggerDeleteJob : ITriggerEventsJob, ITriggerHandler
    {
        public ComponentDataFromEntity<BallTag> BallEntities;
        [ReadOnly] public ComponentDataFromEntity<DeleteTag> EntitiesToDelete;
        public EntityCommandBuffer CommandBuffer;
        
        public void Execute(TriggerEvent triggerEvent)
        {
            var entityPair = triggerEvent.Entities;
            OnTriggerEvent(entityPair.EntityA, entityPair.EntityB);
            OnTriggerEvent(entityPair.EntityB, entityPair.EntityA);
        }

        public void OnTriggerEvent(Entity current, Entity other)
        {
            if (BallEntities.HasComponent(current))
            {
                if (EntitiesToDelete.HasComponent(other)) return;
                CommandBuffer.AddComponent<DeleteTag>(other);
            }
        }
    }
}