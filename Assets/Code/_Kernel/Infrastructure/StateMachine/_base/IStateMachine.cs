namespace Infrastructure.StateMachine {
   public interface IStateMachine<in TStateContract> where TStateContract : IState {
      void Enter<TState>() where TState : class, TStateContract;

      void Enter<TState, TData>(TData data) where TState : class, TStateContract, IDataRequireState<TData>;
   }
}