using Events;
using Extensions.Ecs;
using Extensions.Unileo;
using Gameplay.HitBoxes.Comps;
using Gameplay.HitBoxes.Structs;
using Gameplay.UnityRef.Transform.Comp;
using Gameplay.UnityRef.Transform.Extensions;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.HitBoxes.Sys {
   public class CreateHitEventSys : IEcsRunSystem, IEcsInitSystem {
      private readonly EventsBus      _eventsBus;
      private readonly RaycastHit2D[] _hits;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<EcsTransform> _ecsTransformPool;
      private EcsPool<HitBox>       _hitBoxPool;



      public CreateHitEventSys(EventsBus eventsBus) {
         _eventsBus = eventsBus;
         _hits      = new RaycastHit2D[16];
      }

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<HitBox>().End();

         _hitBoxPool       = _world.GetPool<HitBox>();
         _ecsTransformPool = _world.GetPool<EcsTransform>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int dealerE in _filter) {
            ref HitBox hitBox = ref _hitBoxPool.Get(dealerE);

            Area area      = ToWorldArea(dealerE, hitBox.Area, out float angle);
            int  hitsCount = CastHit(area, angle);

            for (var i = 0; i < hitsCount; i++) {
               RaycastHit2D hit = _hits[i];

               if (hit.collider.ParentEntity(out int takerE))
                  _eventsBus.NewEvent<HitEvent>() = new HitEvent {
                     dealer = dealerE, //
                     taker  = takerE,
                     point  = hit.point,
                     normal = hit.normal
                  };
               else
                  UnityEngine.Debug.Log($"Hit non Entity: {hit.collider.name}");
            }
         }
      }



      private Area ToWorldArea(int dealerE, Area area, out float angle) {
         angle = 0f;

         if (!_ecsTransformPool.TryGet(dealerE, out EcsTransform dealerT))
            return area;

         area.size   *= dealerT.Scale;
         area.origin *= dealerT.Scale;
         area.origin += dealerT.Position;
         angle       =  dealerT.EulerAngles().z;
         return area;
      }

      private int CastHit(Area area, float angle)
         => Physics2D.BoxCastNonAlloc(
            area.origin,
            area.size,
            angle,
            direction: default,
            _hits,
            distance: default
         );
   }
}