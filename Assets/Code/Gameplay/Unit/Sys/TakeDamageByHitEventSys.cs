using Events;
using Gameplay.HitBoxes.Comps;
using Gameplay.Unit.Comps;
using Leopotam.EcsLite;

namespace Gameplay.Unit.Sys {
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

            int takerE  = hitEvent.taker;
            int dealerE = hitEvent.dealer;

            if (_healthPool.Has(takerE) && _damagePool.Has(dealerE))
               _healthPool.Get(takerE).cur -= _damagePool.Get(dealerE).value;
         }
      }
   }
}