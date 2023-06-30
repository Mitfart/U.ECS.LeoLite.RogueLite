namespace Infrastructure.StateMachine.States {
   public class BootstrapState : GameState {
      public override void Enter() {
         UnityEngine.Debug.Log(message: "Main Menu -> Play Imitation");
         StateMachine.Enter<SetupGameState>();
      }
   }
}