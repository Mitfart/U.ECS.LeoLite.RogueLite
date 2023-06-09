using Extensions.Ecs;
using Gameplay.HitBoxes.Comps;
using Gameplay.HitBoxes.Extensions;
using Gameplay.HitBoxes.Structs;
using Gameplay.UnityRef.Transform.Comp;
using Gameplay.UnityRef.Transform.Extensions;
using Infrastructure.Services.Gizmos;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.HitBoxes.Debug {
   public class DebugHitBoxSys : IEcsRunSystem, IEcsInitSystem {
      private readonly GizmosService _gizmosService;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<HitBox>       _hitBoxPool;
      private EcsPool<EcsTransform> _ecsTransformPool;


      public DebugHitBoxSys(GizmosService gizmosService) {
         _gizmosService = gizmosService;
      }

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<HitBox>().End();

         _hitBoxPool       = _world.GetPool<HitBox>();
         _ecsTransformPool = _world.GetPool<EcsTransform>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            Area area = _hitBoxPool.Get(e).area;

            Matrix4x4 matrix = _ecsTransformPool.TryGet(e, out EcsTransform transform) ? transform.Matrix() : Matrix4x4.identity;

            _gizmosService.Draw(() => area.DrawGizmos(matrix, Color.red));
         }
      }
   }
}