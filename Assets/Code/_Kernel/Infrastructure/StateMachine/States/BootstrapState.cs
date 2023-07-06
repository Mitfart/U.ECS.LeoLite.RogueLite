using UnityEngine;

namespace Infrastructure.StateMachine.States {
   public class BootstrapState : GameState {
      public BootstrapState(IGameStateMachine gameStateMachine) : base(gameStateMachine) { }

      public override void Enter() {
         Debug.Log(message: "Main Menu -> Play Imitation");
         StateMachine.Enter<SetupGameState>();
      }
   }
}