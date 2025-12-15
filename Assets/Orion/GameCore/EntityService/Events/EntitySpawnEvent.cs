namespace Orion.GameCore.EntityService.Events
{
    public class EntitySpawnEvent
    {
        public EntityIdentifier EntityIdentifier { get; set; }
        
        public EntitySpawnEvent(EntityIdentifier entityIdentifier)
        {
            EntityIdentifier = entityIdentifier;
        }

        public EntitySpawnEvent()
        {
        }
    }
}