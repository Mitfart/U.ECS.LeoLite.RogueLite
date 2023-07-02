using Engine.Ecs;
using Gameplay.HitBoxes.Comps;
using VContainer;

namespace Events {
   public class ClearEventsPack : EcsSystemsPack {
      private const int _EVENTS_CAPACITY = 128;

      protected override void RegisterSystems()
         => AddByConfiguration(
            res =>
               res.Resolve<EventsBus>()
                  .GetDestroyEventsSystem(_EVENTS_CAPACITY)
                  .IncReplicant<HitEvent>()
         );
   }
}