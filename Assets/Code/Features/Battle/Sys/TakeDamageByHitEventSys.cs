using Events;
using Features.Battle.Extensions;
using Leopotam.EcsLite;

namespace Features.Battle {
  public class TakeDamageByHitEventSys : IEcsRunSystem, IEcsInitSystem {
    private readonly EventsBus _eventBus;
    private          EcsWorld  _world;

    private EcsPool<Health> _healthPool;



    public TakeDamageByHitEventSys(EventsBus eventBus) {
      _eventBus = eventBus;
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();

      _healthPool = _world.GetPool<Health>();
    }

    public void Run(IEcsSystems systems) {
      foreach (int ev in _eventBus.GetEventBodies(out EcsPool<HitEvent> hitEventPool)) {
        ref HitEvent hitEvent = ref hitEventPool.Get(ev);

        if (!hitEvent.TakerAlive(out int takerE)
         || !_healthPool.Has(takerE))
          continue;

        _healthPool.Get(takerE).cur -= hitEvent.damage;
      }
    }
  }
}