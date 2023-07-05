using Events;
using Extensions.Ecs;
using Gameplay.HitBoxes.Comps;
using Gameplay.Unit.Comps;
using Infrastructure.Services.Time;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.HitBoxes.Sys {
   public class InvincibilityAfterHitEventSys : IEcsRunSystem, IEcsInitSystem {
      private readonly EventsBus    _eventsBus;
      private readonly ITimeService _timeService;

      private EcsWorld _world;

      private EcsPool<Invincible>            _invinciblePool;
      private EcsPool<InvincibilityDuration> _invincibilityDurationPool;



      public InvincibilityAfterHitEventSys(EventsBus eventsBus, ITimeService timeService) {
         _eventsBus   = eventsBus;
         _timeService = timeService;
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



      private void  MakeInvincible(int takerE) => _invinciblePool.Add(takerE) = new Invincible { duration = Duration(takerE), startTime = _timeService.Time };
      private bool  Invincible(int     takerE) => _invinciblePool.Has(takerE);
      private float Duration(int       takerE) => _invincibilityDurationPool.TryGet(takerE, out InvincibilityDuration duration) ? duration.duration : 0f;
   }
}