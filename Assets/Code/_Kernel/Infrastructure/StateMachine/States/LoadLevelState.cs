using Infrastructure.AssetsManagement;
using Infrastructure.Loading;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.States {
  public class LoadLevelState : GameState, IDataRequireState<string> {
    private readonly ISceneLoader    _sceneLoader;
    private readonly ILoadingCurtain _loadingCurtain;
    private readonly Controls        _controls;
    private readonly Assets          _assets;

    private string _levelSceneName;



    public LoadLevelState(
      ISceneLoader    sceneLoader,
      ILoadingCurtain loadingCurtain,
      Controls        controls,
      Assets          assets
    ) {
      _sceneLoader    = sceneLoader;
      _loadingCurtain = loadingCurtain;
      _controls       = controls;
      _assets         = assets;
    }

    public IDataRequireState<string> SetData(string data) {
      _levelSceneName = data;
      return this;
    }



    public override void Enter() {
      _controls.Disable();

      _assets.InsRender();
      _loadingCurtain.Show();

      StartLoadScene();
    }

    public override void Exit() {
      _loadingCurtain.Hide();
    }



    private void StartLoadScene() {
#if UNITY_EDITOR
      if (SceneManager.GetActiveScene().name == _levelSceneName) {
        OnLoaded();
        return;
      }
#endif
      _sceneLoader.Load(_levelSceneName, OnLoaded);
    }

    private void OnLoaded() => StateMachine.Enter<GameLoopState>();
  }
}