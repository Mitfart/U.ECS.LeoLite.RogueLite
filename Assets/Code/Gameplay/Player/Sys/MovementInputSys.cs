﻿using Gameplay.Movement.Comps;
using Gameplay.Player.Comps;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Player.Sys {
   public class MovementInputSys : IEcsRunSystem, IEcsInitSystem {
      private readonly Controls _controls;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<MoveDirection> _moveDirectionPool;



      public MovementInputSys(Controls controls) {
         _controls = controls;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<PlayerTag>()
                         .Inc<MoveDirection>()
                         .End();

         _moveDirectionPool = _world.GetPool<MoveDirection>();
      }

      public void Run(IEcsSystems systems) {
         Vector2 input = _controls.Game.Move.ReadValue<Vector2>();

         foreach (int e in _filter) {
            _moveDirectionPool.Get(e).value = input;
         }
      }
   }
}