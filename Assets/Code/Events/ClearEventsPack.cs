using Engine.Ecs;
using VContainer;

namespace Events {
  public class ClearEventsPack : EcsSystemsPack {
    private const int EVENTS_CAPACITY = 128;
    
    protected override void RegisterSystems() {
      AddByConfiguration(
        res =>
          res.Resolve<EventsBus>()
             .GetDestroyEventsSystem(EVENTS_CAPACITY)
             //.IncReplicant<HitEvent>()
      );
    }
  }
}