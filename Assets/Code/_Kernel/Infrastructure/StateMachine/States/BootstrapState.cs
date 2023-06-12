namespace Infrastructure.StateMachine.States {
  public class BootstrapState : GameState {
    public override void Enter() {
      StateMachine.Enter<LoadLevelState, string>(Scenes.MAIN);
    }
  }
}