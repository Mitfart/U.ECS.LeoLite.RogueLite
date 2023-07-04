namespace Infrastructure.StateMachine {
   public interface IGameState : IState {
      public IGameStateMachine StateMachine { get; }
   }
}