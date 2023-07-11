using Gameplay.Movement.Comps;
using Gameplay.Unit.Behavior.ECS.Comps;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Unit.Behavior.ECS.Sys {
   public class MoveByPathSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Path>   _pathPool;
      private EcsPool<MoveTo> _moveToPool;



      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<Path>()
                         .Inc<MoveTo>()
                         .End();

         _pathPool   = _world.GetPool<Path>();
         _moveToPool = _world.GetPool<MoveTo>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            ref Path path = ref Path(e);

            if (path.Exist)
               MoveTo(e, path.NextCorner());
         }
      }



      private     void MoveTo(int e, Vector3 pos) => _moveToPool.Get(e).position = pos;
      private ref Path Path(int   e) => ref _pathPool.Get(e);
   }
}