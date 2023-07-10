using Extensions.Ecs;
using Gameplay.Player.Comps;
using Gameplay.Unit.Behavior;
using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.AI;

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
         _filter = _world.Filter<Player>()
                         .Inc<EcsTransform>()
                         .End();

         _pathPool         = _world.GetPool<Path>();
         _ecsTransformPool = _world.GetPool<EcsTransform>();
      }

      public void Run(IEcsSystems systems) {
         if (!MouseUtils.LeftBtn())
            return;

         Vector2 mousePos = MouseUtils.WorldPos2D();

         foreach (int e in _filter) {
            _navService
              .CalcPath(
                  Position(e),
                  mousePos,
                  Path(e)
               );
         }
      }

      
      
      private Vector3     Position(int e) => _ecsTransformPool.Get(e).Position;
      private NavMeshPath Path(int     e) => _pathPool.Set(e).Value;
   }
}