using Engine.Ecs;
using Extentions;
using VContainer;

namespace Events {
  public class DestroyEvents : EcsSystemsPack {
    private const int EVENTS_CAPACITY = 128;
    
    protected override void RegisterSystems() {
      AddByConfiguration(
        res =>
          res.Resolve<EventsBus>()
             .GetDestroyEventsSystem(EVENTS_CAPACITY)
             .IncReplicant<HitEvent>()
      );
    }
  }

  public struct HitEvent : IEvent { }
}