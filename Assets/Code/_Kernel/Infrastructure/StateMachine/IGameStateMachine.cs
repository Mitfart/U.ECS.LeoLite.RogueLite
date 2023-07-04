using System.Collections.Generic;

namespace Infrastructure.StateMachine {
   public interface IGameStateMachine : IStateMachine<IGameState> {
      IGameStateMachine RegisterStates(IReadOnlyList<IGameState> gameStates);
   }
}