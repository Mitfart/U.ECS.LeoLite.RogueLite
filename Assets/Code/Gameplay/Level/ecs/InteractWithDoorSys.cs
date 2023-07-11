using Gameplay.Level.ecs.tmp.Comp;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using Leopotam.EcsLite;

namespace Gameplay.Level.ecs.tmp.Sys {
   public class InteractWithDoorSys : IEcsRunSystem, IEcsInitSystem {
      private readonly IGameStateMachine _stateMachine;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Door>                      _doorPool;
      private EcsPool<Interactable.Interactable> _interactablePool;



      public InteractWithDoorSys(IGameStateMachine stateMachine) {
         _stateMachine = stateMachine;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<Door>()
                         .Inc<Interactable.Interactable>()
                         .End();

         _doorPool         = _world.GetPool<Door>();
         _interactablePool = _world.GetPool<Interactable.Interactable>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            if (!Interacted(e))
               continue;

            _stateMachine.Enter<LoadLevelState, NextLevel>(NextLevel(e));
            return;
         }
      }

      
      
      private bool      Interacted(int e) => _interactablePool.Get(e).state == Interactable.Interactable.State.Interacted;
      private NextLevel NextLevel(int  e) => _doorPool.Get(e).NextLevel;
   }
}