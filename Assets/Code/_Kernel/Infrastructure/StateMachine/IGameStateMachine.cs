using VContainer.Unity;

namespace Infrastructure.StateMachine {
  public interface IGameStateMachine : IStateMachine<IGameState>, ITickable, IFixedTickable { }
}