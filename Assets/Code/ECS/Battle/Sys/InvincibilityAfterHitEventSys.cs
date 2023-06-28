using ECS.Unit.Comps;
using Events;
using Extensions.Ecs;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Battle {
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

               if (PassInvincibilityTime(takerE)) MakeNotInvincible(takerE);
               continue;
            }

            MakeInvincible(takerE);
         }
      }



      private bool PassInvincibilityTime(int takerE) {
         return Time.time - _invinciblePool.Get(takerE).startTime > _invinciblePool.Get(takerE).duration;
      }

      private void MakeNotInvincible(int takerE) {
         _invinciblePool.Del(takerE);
      }

      private void MakeInvincible(int takerE) {
         _invinciblePool.Add(takerE) = new Invincible(Duration(takerE));
      }

      private bool Invincible(int takerE) {
         return _invinciblePool.Has(takerE);
      }

      private float Duration(int takerE) {
         return _invincibilityDurationPool.TryGet(takerE, out InvincibilityDuration duration) ? duration.duration : 0f;
      }
   }
}