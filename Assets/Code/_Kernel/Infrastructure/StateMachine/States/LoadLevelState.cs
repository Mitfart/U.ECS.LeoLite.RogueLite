using Infrastructure.Loading;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.States {
  public class LoadLevelState : GameState, IDataRequireState<string> {
    private readonly Controls _controls;

    private readonly ISceneLoader _sceneLoader;
    //private readonly ILoadingCurtain _loadingCurtain;

    private string _sceneName;



    public LoadLevelState(
      ISceneLoader sceneLoader,
      Controls     controls //, ILoadingCurtain   loadingCurtain
    ) {
      _sceneLoader = sceneLoader;
      _controls    = controls;

      //_loadingCurtain   = loadingCurtain;
    }

    public IDataRequireState<string> SetData(string data) {
      _sceneName = data;
      return this;
    }



    public override void Enter() {
      _controls.Disable();

      //_loadingCurtain.Show();

      StartLoadScene();
    }

    public override void Exit() {
      //_loadingCurtain.Hide();
    }



    private void StartLoadScene() {
#if UNITY_EDITOR
      if (SceneManager.GetActiveScene().name != _sceneName)
        _sceneLoader.Load(_sceneName, OnLoaded);
      else
        OnLoaded();
#else
            _sceneLoader.Load(_sceneName, OnLoaded);
#endif
    }

    private void OnLoaded() {
      StateMachine.Enter<GameLoopState>();
    }
  }
}