using Gameplay.Interactable;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using Leopotam.EcsLite;

namespace Gameplay.Level.Sys {
   public class InteractWithDoorSys : IEcsRunSystem, IEcsInitSystem {
      private readonly IGameStateMachine _stateMachine;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Door> _doorPool;



      public InteractWithDoorSys(IGameStateMachine stateMachine) {
         _stateMachine = stateMachine;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<Door>()
                         .Inc<Interacted>()
                         .End();

         _doorPool = _world.GetPool<Door>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            ref Door door = ref _doorPool.Get(e);

            _stateMachine.Enter<LoadLevelState, NextLevel>(door.NextLevel);
         }
      }
   }
}