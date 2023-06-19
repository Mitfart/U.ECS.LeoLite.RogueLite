using Events;
using Features.Battle;
using Features.Battle.Extensions;
using Leopotam.EcsLite;

namespace Features.Weapon.Projectiles {
  public class DestroyAfterHitsSys : IEcsRunSystem, IEcsInitSystem {
    private readonly EventsBus _eventsBus;
    private          EcsWorld  _world;

    private EcsPool<DestroyAfterHits> _destroyAfterHitsPool;
    private EcsPool<Destroy.Destroy>  _destroyPool;



    public DestroyAfterHitsSys(EventsBus eventsBus) {
      _eventsBus = eventsBus;
    }

    public void Run(IEcsSystems systems) {
      foreach (int e in _eventsBus.GetEventBodies(out EcsPool<HitEvent> hitEvents)) {
        ref HitEvent hitEvent = ref hitEvents.Get(e);

        if (!hitEvent.DealerAlive(out int dealerE)
         || !_destroyAfterHitsPool.Has(dealerE)
         || _destroyPool.Has(dealerE))
          continue;

        ref DestroyAfterHits destroyAfterHits = ref _destroyAfterHitsPool.Get(e);
        destroyAfterHits.elapsedCount++;

        if (destroyAfterHits.elapsedCount >= destroyAfterHits.amount) {
          _destroyPool.Add(dealerE);
          destroyAfterHits.elapsedCount = 0;
        }
      }
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();

      _destroyAfterHitsPool = _world.GetPool<DestroyAfterHits>();
      _destroyPool          = _world.GetPool<Destroy.Destroy>();
    }
  }
}