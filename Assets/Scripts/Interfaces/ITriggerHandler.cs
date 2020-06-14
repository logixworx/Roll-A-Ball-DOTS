using Unity.Entities;

namespace Interfaces
{
    public interface ITriggerHandler
    {
        void OnTriggerEvent(Entity current, Entity other);
    }
}