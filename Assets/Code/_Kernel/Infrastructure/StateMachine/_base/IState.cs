namespace Infrastructure.StateMachine {
   public interface IState {
      void Enter();
      void Exit();
   }
}