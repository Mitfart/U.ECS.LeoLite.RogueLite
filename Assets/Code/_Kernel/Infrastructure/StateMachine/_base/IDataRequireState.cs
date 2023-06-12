namespace Infrastructure.StateMachine {
  public interface IDataRequireState<in T> : IState {
    IDataRequireState<T> SetData(T data);
  }
}