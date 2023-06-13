using Engine;

namespace Infrastructure.StateMachine.States {
  public class GameLoopState : GameState {
    private readonly IEngine  _engine;
    private readonly Controls _controls;



    public GameLoopState(IEngine engine, Controls controls) {
      _engine        = engine;
      _controls = controls;
    }


    public override void Enter() {
      _controls.Game.Enable();
      _engine.Start();
    }

    public override void Exit() {
      _controls.Game.Disable();
      _engine.Stop();
    }
  }
}