using Components;
using Jobs;
using Tags;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;

namespace Systems
{
    public class CollectSystem : JobComponentSystem
    {
        public BeginInitializationEntityCommandBufferSystem CommandBufferSystem;
        public BuildPhysicsWorld BuildPhysicsWorld;
        public StepPhysicsWorld StepPhysicsWorld;

        protected override void OnCreate()
        {
            CommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
            BuildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
            StepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var onTriggerDeleteJob = new OnTriggerDeleteJob
            {
                BallEntities = GetComponentDataFromEntity<BallTag>(),
                EntitiesToDelete = GetComponentDataFromEntity<DeleteTag>(),
                CommandBuffer = CommandBufferSystem.CreateCommandBuffer()
            };

            return onTriggerDeleteJob.Schedule(StepPhysicsWorld.Simulation, ref BuildPhysicsWorld.PhysicsWorld, inputDeps);
        }
    }
}