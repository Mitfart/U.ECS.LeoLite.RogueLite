using Gameplay.Interactable;
using Gameplay.Level.ecs.tmp.Comp;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using Leopotam.EcsLite;

namespace Gameplay.Level.ecs.tmp.Sys {
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
            _stateMachine.Enter<LoadLevelState, NextLevel>(NextLevel(e));
            return;
         }
      }



      private NextLevel NextLevel(int e) => _doorPool.Get(e).NextLevel;
   }
}