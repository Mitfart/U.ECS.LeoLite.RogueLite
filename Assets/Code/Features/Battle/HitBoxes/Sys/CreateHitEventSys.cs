using Events;
using Extensions.Ecs;
using Extensions.EcsTransform;
using Extensions.Unileo;
using Leopotam.EcsLite;
using UnityEngine;
using UnityRef;

namespace Features.Battle.HitBoxes.Sys {
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
      _world = systems.GetWorld();
      _filter = _world
               .Filter<HitBox>()
               .End();

      _hitBoxPool       = _world.GetPool<HitBox>();
      _ecsTransformPool = _world.GetPool<EcsTransform>();
    }

    public void Run(IEcsSystems systems) {
      foreach (int dealerE in _filter) {
        ref HitBox hitBox = ref _hitBoxPool.Get(dealerE);

        Area      area      = ToWorldArea(dealerE, hitBox.Area, out float angle);
        LayerMask layer     = hitBox.LayerMask;
        int       hitsCount = CastHit(area, angle, layer);

        for (var i = 0; i < hitsCount; i++) {
          RaycastHit2D hit = _hits[i];

          if (hit.collider.ParentEntity(out int takerE))
            _eventsBus.NewEvent<HitEvent>() = new HitEvent {
              Dealer = _world.PackEntityWithWorld(dealerE),
              Taker  = _world.PackEntityWithWorld(takerE),
              point  = hit.point,
              normal = hit.normal
            };
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

    private int CastHit(Area area, float angle, LayerMask layer)
      => Physics2D.BoxCastNonAlloc(
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