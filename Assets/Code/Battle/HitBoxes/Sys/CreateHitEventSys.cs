using Events;
using Extensions.Ecs;
using Extensions.Unileo;
using Extentions;
using Leopotam.EcsLite;
using UnityEngine;

namespace Battle.HitBoxes.Sys {
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

    public void Run(IEcsSystems systems) {
      foreach (int dealerE in _filter) {
        ref HitBox hitBox = ref _hitBoxPool.Get(dealerE);

        Area      area      = ToWorldArea(dealerE, hitBox.Area, out float angle);
        LayerMask layer     = hitBox.LayerMask;
        int       hitsCount = CastHit(area, angle, layer);

        for (var i = 0; i < hitsCount; i++) {
          RaycastHit2D hit = _hits[i];

          if (hit.collider.TryGetEntity(out int takerE)) {
            _eventsBus.NewEvent<HitEvent>() = new HitEvent {
              Dealer = _world.PackEntity(dealerE),
              Taker  = _world.PackEntity(takerE),
              Point  = hit.point,
              Normal = hit.normal
            };
          }
        }
      }
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world
               .Filter<HitBox>()
               .End();

      _hitBoxPool       = _world.GetPool<HitBox>();
      _ecsTransformPool = _world.GetPool<EcsTransform>();
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

    private int CastHit(Area area, float angle, LayerMask layer) {
      return Physics2D.BoxCastNonAlloc(
        area.origin,
        area.size,
        angle,
        default,
        _hits,
        default,
        layer
      );
    }
  }
}