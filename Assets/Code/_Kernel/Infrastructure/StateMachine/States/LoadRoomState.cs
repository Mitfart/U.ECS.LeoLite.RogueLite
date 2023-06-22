using Infrastructure.Loading;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.States {
  public class LoadRoomState : GameState, IDataRequireState<string> {
    private readonly ISceneLoader    _sceneLoader;
    private readonly ILoadingCurtain _loadingCurtain;
    private readonly Controls        _controls;

    private string _roomSceneName;



    public LoadRoomState(
      ISceneLoader    sceneLoader,
      ILoadingCurtain loadingCurtain,
      Controls        controls
    ) {
      _sceneLoader    = sceneLoader;
      _loadingCurtain = loadingCurtain;
      _controls       = controls;
    }

    public IDataRequireState<string> SetData(string roomSceneName) {
      _roomSceneName = roomSceneName;
      return this;
    }



    public override void Enter() {
      _controls.Disable();

      _loadingCurtain.Show();

      LoadRoom();
    }

    public override void Exit() {
      _loadingCurtain.Hide();
    }



    private void LoadRoom() {
#if UNITY_EDITOR
      if (SceneManager.GetActiveScene().name == _roomSceneName) {
        OnLoaded();
        return;
      }
#endif
      _sceneLoader.Load(_roomSceneName, OnLoaded);
    }

    private void OnLoaded() => StateMachine.Enter<GameLoopState>();
  }
}