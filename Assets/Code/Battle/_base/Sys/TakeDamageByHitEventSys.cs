using Battle.HitBoxes;
using Battle.HitBoxes.Extensins;
using Events;
using Extensions.Ecs;
using Leopotam.EcsLite;

namespace Battle {
  public class TakeDamageByHitEventSys : IEcsRunSystem, IEcsInitSystem {
    private readonly EventsBus _eventBus;
    private          EcsWorld  _world;

    private EcsPool<Health> _healthPool;
    private EcsPool<Damage> _damagePool;



    public TakeDamageByHitEventSys(EventsBus eventBus) {
      _eventBus = eventBus;
    }


    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();

      _healthPool = _world.GetPool<Health>();
      _damagePool = _world.GetPool<Damage>();
    }

    public void Run(IEcsSystems systems) {
      foreach (int ev in _eventBus.GetEventBodies(out EcsPool<HitEvent> hitEventPool)) {
        ref HitEvent hitEvent = ref hitEventPool.Get(ev);

        if (hitEvent.TakerDead(_world, out int takerE)
         || hitEvent.DealerDead(_world, out int dealerE))
          return;

        ref Health health = ref _healthPool.Get(takerE);
        float      damage = _damagePool.TryGet(dealerE, out Damage dam) ? dam.value : 0f;

        health.cur -= damage;
      }
    }
  }
}