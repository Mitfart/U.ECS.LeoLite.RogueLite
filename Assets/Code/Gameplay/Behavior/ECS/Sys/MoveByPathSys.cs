using Gameplay.Movement.Comps;
using Gameplay.Unit.Behavior.ECS.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Unit.Behavior.ECS.Sys {
   public class MoveByPathSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Path>          _pathPool;
      private EcsPool<MoveTo> _moveDirectionPool;
      private EcsPool<EcsTransform>  _ecsTransformPool;



      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<Path>()
                         .Inc<MoveTo>()
                         .Inc<EcsTransform>()
                         .End();

         _pathPool          = _world.GetPool<Path>();
         _moveDirectionPool = _world.GetPool<MoveTo>();
         _ecsTransformPool  = _world.GetPool<EcsTransform>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter)
            SetMoveDirection(e, MoveDirection(e));
      }



      private void    SetMoveDirection(int e, Vector3 dir) => _moveDirectionPool.Get(e).position = dir;
      private Vector3 MoveDirection(int    e) => _pathPool.Get(e).MoveDirection(Position(e));
      private Vector3 Position(int         e) => _ecsTransformPool.Get(e).Position;
   }
}