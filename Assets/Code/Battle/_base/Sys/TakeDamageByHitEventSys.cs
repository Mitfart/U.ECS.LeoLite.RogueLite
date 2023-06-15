using Battle.HitBoxes;
using Battle.HitBoxes.Extensins;
using Events;
using Leopotam.EcsLite;

namespace Battle {
  public class TakeDamageByHitEventSys : IEcsRunSystem, IEcsInitSystem {
    private          EcsWorld  _world;
    private readonly EventsBus _eventBus;

    private EcsPool<Health> _healthPool;
    private EcsPool<Damage> _damagePool;



    public TakeDamageByHitEventSys(EventsBus eventBus) {
      _eventBus = eventBus;
    }

    public void Run(IEcsSystems systems) {
      foreach (int ev in _eventBus.GetEventBodies(out EcsPool<HitEvent> hitEventPool)) {
        ref HitEvent hitEvent = ref hitEventPool.Get(ev);

        if (hitEvent.TakerDead(_world, out int takerE)
         || hitEvent.DealerDead(_world, out int dealerE))
          return;

        ref Health health = ref _healthPool.Get(takerE);
        ref Damage damage = ref _damagePool.Get(dealerE);

        health.cur -= damage.value;
      }
    }


    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();

      _healthPool = _world.GetPool<Health>();
      _damagePool = _world.GetPool<Damage>();
    }
  }
}