namespace Infrastructure.StateMachine {
   public abstract class GameState : IGameState {
      public IGameStateMachine StateMachine { get; private set; }


      public void Init(IGameStateMachine stateMachine) => StateMachine = stateMachine;

      public abstract void Enter();
      public virtual  void Exit() { }
   }
}