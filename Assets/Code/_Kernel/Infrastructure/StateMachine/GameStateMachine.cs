using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachine {
   public class GameStateMachine : IGameStateMachine {
      private Dictionary<Type, IGameState> _states;

      private IGameState _currentState;



      public IGameStateMachine RegisterStates(IReadOnlyList<IGameState> gameStates) {
         _states = new Dictionary<Type, IGameState>(gameStates.Count);

         foreach (IGameState gameState in gameStates)
            RegisterState(gameState);
         
         return this;
      } 
      
      

      public void Enter<TState>() where TState : class, IGameState //                                    
         => ChangeState<TState>().Enter();

      public void Enter<TState, TData>(TData data) where TState : class, IGameState, IDataRequireState<TData> //
         => ChangeState<TState>().SetData(data).Enter();



      private void RegisterState<TState>(TState state) where TState : IGameState => _states.Add(state.GetType(), state);

      private TState ChangeState<TState>() where TState : class, IGameState {
         _currentState?.Exit();

         TState state = GetState<TState>();
         _currentState = state;

         return state;
      }

      private TState GetState<TState>() where TState : class, IGameState => (TState)_states[typeof(TState)];
   }
}