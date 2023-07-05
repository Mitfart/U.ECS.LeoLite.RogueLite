using Events;
using Extensions.Ecs;
using Gameplay.HitBoxes.Comps;
using Gameplay.Unit.Comps;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.HitBoxes.Sys {
   public class InvincibilityAfterHitEventSys : IEcsRunSystem, IEcsInitSystem {
      private readonly EventsBus _eventsBus;
      private          EcsWorld  _world;

      private EcsPool<Invincible>            _invinciblePool;
      private EcsPool<InvincibilityDuration> _invincibilityDurationPool;



      public InvincibilityAfterHitEventSys(EventsBus eventsBus) {
         _eventsBus = eventsBus;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();

         _invinciblePool            = _world.GetPool<Invincible>();
         _invincibilityDurationPool = _world.GetPool<InvincibilityDuration>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int ev in _eventsBus.GetEventBodies(out EcsPool<HitEvent> hitEventPool)) {
            ref HitEvent hitEvent = ref hitEventPool.Get(ev);
            int          takerE   = hitEvent.taker;

            if (Invincible(takerE)) {
               hitEventPool.Del(ev);
               continue;
            }

            MakeInvincible(takerE);
         }
      }



      private void  MakeInvincible(int takerE) => _invinciblePool.Add(takerE) = new Invincible { duration = Duration(takerE), startTime = Time.time };
      private bool  Invincible(int     takerE) => _invinciblePool.Has(takerE);
      private float Duration(int       takerE) => _invincibilityDurationPool.TryGet(takerE, out InvincibilityDuration duration) ? duration.duration : 0f;
   }
}