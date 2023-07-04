using Engine;

namespace Infrastructure.StateMachine.States {
   public class GameLoopState : GameState {
      private readonly Controls _controls;
      private readonly IEngine  _engine;

      public GameLoopState(
         IGameStateMachine stateMachine,
         Controls          controls,
         IEngine           engine
      ) : base(stateMachine) {
         _controls = controls;
         _engine   = engine;
      }

      public override void Enter() {
         _controls.Enable();
         _engine.Enable();
      }

      public override void Exit() {
         _controls.Disable();
         _engine.Disable();
      }
   }
}