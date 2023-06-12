namespace Infrastructure.StateMachine {
  public interface IGameState : IState {
    public IGameStateMachine StateMachine { get; }

    public void Init(IGameStateMachine stateMachine);
  }
}