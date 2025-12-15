namespace Orion.GameCore.EntityService.Events
{
    public class EntityDestroyEvent
    {
        public EntityIdentifier EntityIdentifier { get; set; }
        
        public EntityDestroyEvent(EntityIdentifier entityIdentifier)
        {
            EntityIdentifier = entityIdentifier;
        }

        public EntityDestroyEvent()
        {
        }
    }
}