using Gameplay.Movement.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Player.Sys {
   public class MovementInputSys : IEcsRunSystem, IEcsInitSystem {
      private readonly Controls _controls;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<MoveTo>       _moveDirectionPool;
      private EcsPool<EcsTransform> _ecsTransformPool;



      public MovementInputSys(Controls controls) {
         _controls = controls;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<Comps.Player>()
                         .Inc<MoveTo>()
                         .Inc<EcsTransform>()
                         .End();

         _moveDirectionPool = _world.GetPool<MoveTo>();
         _ecsTransformPool  = _world.GetPool<EcsTransform>();
      }

      public void Run(IEcsSystems systems) {
         Vector2 input = _controls.Game.Move.ReadValue<Vector2>();

         foreach (int e in _filter)
            MoveTo(e, Position(e) + (Vector3)input);
      }



      private Vector3 Position(int e)              => _ecsTransformPool.Get(e).Position;
      private void    MoveTo(int   e, Vector3 pos) => _moveDirectionPool.Get(e).position = pos;
   }
}