namespace Infrastructure.StateMachine {
   public abstract class GameState : IGameState {
      public IGameStateMachine StateMachine { get; }



      protected GameState(IGameStateMachine gameStateMachine) {
         StateMachine = gameStateMachine;
      }

      public abstract void Enter();
      public virtual  void Exit() { }
   }
}