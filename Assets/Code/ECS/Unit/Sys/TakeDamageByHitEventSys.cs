using Events;
using Leopotam.EcsLite;

namespace Features.Battle {
  public class TakeDamageByHitEventSys : IEcsRunSystem, IEcsInitSystem {
    private readonly EventsBus _eventBus;
    private          EcsWorld  _world;

    private EcsPool<Health> _healthPool;



    public TakeDamageByHitEventSys(EventsBus eventBus) {
      _eventBus = eventBus;
    }

    public void Run(IEcsSystems systems) {
      foreach (int ev in _eventBus.GetEventBodies(out EcsPool<HitEvent> hitEventPool)) {
        ref HitEvent hitEvent = ref hitEventPool.Get(ev);
        int          takerE   = hitEvent.taker;
        float        damage   = hitEvent.damage;

        if (_healthPool.Has(takerE))
          _healthPool.Get(takerE).cur -= damage;
      }
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();

      _healthPool = _world.GetPool<Health>();
    }
  }
}