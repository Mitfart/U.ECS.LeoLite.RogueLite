using Debug;
using Events;
using Features.Battle.Extensions;
using Leopotam.EcsLite;

namespace Features.Battle.Debug {
  public class HitEventDebugSys : IEcsRunSystem, IEcsInitSystem {
    private readonly GizmosService _gizmosService;
    private readonly EventsBus     _eventsBus;

    private EcsWorld _world;



    public HitEventDebugSys(GizmosService gizmosService, EventsBus eventsBus) {
      _gizmosService = gizmosService;
      _eventsBus     = eventsBus;
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
    }

    public void Run(IEcsSystems systems) {
      foreach (int ev in _eventsBus.GetEventBodies(out EcsPool<HitEvent> hitEventPoll)) {
        HitEvent hitEvent = hitEventPoll.Get(ev);
        _gizmosService.Draw(() => hitEvent.DrawGizmos());
      }
    }
  }
}