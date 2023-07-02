using Events;
using HitBoxes;
using Leopotam.EcsLite;

namespace Unit.Comps {
   public class PenetrationSys : IEcsRunSystem, IEcsInitSystem {
      private readonly EventsBus _eventsBus;
      private          EcsWorld  _world;

      private EcsPool<Penetration>     _destroyAfterHitsPool;
      private EcsPool<Destroy.Destroy> _destroyPool;
      private EcsPool<Invincible>      _invinciblePool;



      public PenetrationSys(EventsBus eventsBus) {
         _eventsBus = eventsBus;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();

         _destroyAfterHitsPool = _world.GetPool<Penetration>();
         _destroyPool          = _world.GetPool<Destroy.Destroy>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int ev in _eventsBus.GetEventBodies(out EcsPool<HitEvent> hitEvents)) {
            ref HitEvent hitEvent = ref hitEvents.Get(ev);
            int          dealerE  = hitEvent.dealer;

            if (!_destroyAfterHitsPool.Has(dealerE) || _destroyPool.Has(dealerE)) continue;

            ref Penetration hits = ref _destroyAfterHitsPool.Get(dealerE);

            if (hits.elapsedCount < hits.amount) {
               hits.elapsedCount++;
               continue;
            }

            _destroyPool.Add(dealerE);
            hits.elapsedCount = 0;
         }
      }
   }
}