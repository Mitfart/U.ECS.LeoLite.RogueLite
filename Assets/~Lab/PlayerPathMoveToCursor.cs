using Extensions.Ecs;
using Gameplay.Player.Comps;
using Gameplay.Unit.Behavior;
using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Lab {
   public class PlayerPathMoveToCursor : IEcsRunSystem, IEcsInitSystem {
      private readonly IAINavService _navService;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Path>         _pathPool;
      private EcsPool<EcsTransform> _ecsTransformPool;



      public PlayerPathMoveToCursor(IAINavService navService) {
         _navService = navService;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<PlayerTag>()
                         .Inc<EcsTransform>()
                         .End();

         _pathPool         = _world.GetPool<Path>();
         _ecsTransformPool = _world.GetPool<EcsTransform>();
      }

      public void Run(IEcsSystems systems) {
         if (!MouseUtils.LeftBtn())
            return;

         Vector2 mousePos = MouseUtils.WorldPos2D();

         foreach (int e in _filter)
            _pathPool
              .Set(e)
              .Calc(
                  _navService,
                  _ecsTransformPool.Get(e).Position,
                  mousePos
               );
      }
   }
}