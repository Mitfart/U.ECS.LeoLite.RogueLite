using Debug;
using VContainer;
using VContainer.Unity;
using Leopotam.EcsLite;
using Engine;
using Events;
using Infrastructure;
using Infrastructure.AssetsManagement;
using Infrastructure.Loading;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using Level;
using Views;

public class GameScope : LifetimeScope {
  private IContainerBuilder _di;

  private Assets _assets;



  protected override void Configure(IContainerBuilder di) {
    _di     = di;
    _assets = new Assets();

    RegSceneLoader();
    RegInputControls();

    RegAssets();

    RegEngine();
    RegGameStateMachine();
  }



  private void RegSceneLoader()   => _di.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
  private void RegInputControls() => _di.Register<Controls>(Lifetime.Singleton);

  private void RegAssets() {
    _di.RegisterInstance(_assets);

    _di.UseComponents(
      di => {
        di.AddInNewPrefab(_assets.Load<GizmosService>(AssetPath.GIZMOS_SERVICE),   Lifetime.Singleton).DontDestroyOnLoad();
        di.AddInNewPrefab(_assets.Load<Render>(AssetPath.RENDER),                  Lifetime.Singleton).DontDestroyOnLoad().As<IRender>();
        di.AddInNewPrefab(_assets.Load<LoadingCurtain>(AssetPath.LOADING_CURTAIN), Lifetime.Singleton).DontDestroyOnLoad().As<ILoadingCurtain>();
      }
    );

    _di.Register(_ => _assets.Load<LocationsDB>(AssetPath.LOCATIONS).Read(), Lifetime.Singleton);
  }

  private void RegEngine() {
    new MainSystemsPack().Install(_di);
    _di.Register(_ => new EcsWorld(), Lifetime.Singleton);
    _di.Register<EventsBus>(Lifetime.Singleton);
    _di.Register<EcsEngine>(Lifetime.Singleton).AsImplementedInterfaces();
  }

  private void RegGameStateMachine() {
    _di.Register<BootstrapState>(Lifetime.Singleton).AsImplementedInterfaces();
    _di.Register<LoadRoomState>(Lifetime.Singleton).AsImplementedInterfaces();
    _di.Register<GameLoopState>(Lifetime.Singleton).AsImplementedInterfaces();

    _di.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);
  }
}