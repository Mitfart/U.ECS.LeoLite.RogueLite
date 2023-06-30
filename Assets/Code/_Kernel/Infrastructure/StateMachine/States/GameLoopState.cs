using Engine;
using VContainer.Unity;

namespace Infrastructure.StateMachine.States {
   public class GameLoopState : GameState, ITickable, IFixedTickable {
      private readonly IEngine  _engine;
      private readonly Controls _controls;



      public GameLoopState(IEngine engine, Controls controls) {
         _engine   = engine;
         _controls = controls;
      }

      public void FixedTick() => _engine.FixedRun();

      public void Tick() => _engine.Run();



      public override void Enter() {
         _controls.Game.Enable();
         _engine.Init();
      }

      public override void Exit() {
         _engine.Dispose();
         _controls.Game.Disable();
      }
   }
}