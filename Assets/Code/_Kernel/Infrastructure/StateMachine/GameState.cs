namespace Infrastructure.StateMachine {
   public abstract class GameState : IGameState {
      protected GameState(IGameStateMachine gameStateMachine) {
         StateMachine = gameStateMachine;
      }

      public IGameStateMachine StateMachine { get; }

      public abstract void Enter();
      public virtual  void Exit() { }
   }
}