using Engine;

namespace Infrastructure.StateMachine.States {
  public class GameLoopState : GameState {
    private readonly IEngine _engine;



    public GameLoopState(IEngine engine) {
      _engine = engine;
    }


    public override void Enter() => _engine.Start();
    public override void Exit()  => _engine.Stop();
  }
}