using VContainer;
using VContainer.Unity;
using Leopotam.EcsLite;
using Engine;
using Events;
using Infrastructure.AssetsManagement;
using Infrastructure.Loading;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;

public class GameScope : LifetimeScope {
  private IContainerBuilder _di;



  protected override void Configure(IContainerBuilder di) {
    _di = di;
    RegAssets();
    RegGizmosService();
    RegSceneLoader();
    RegLoadingCurtain();
    RegInputControls();
    RegLocations();
    RegEngine();
    RegGameStateMachine();
  }


  private void RegAssets() => _di.Register<Assets>(Lifetime.Singleton);

  private void RegGizmosService() => _di.Register(res => res.Resolve<Assets>().InsGizmosService(), Lifetime.Singleton);

  private void RegSceneLoader()    => _di.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
  private void RegLoadingCurtain() => _di.Register<ILoadingCurtain>(res => res.Resolve<Assets>().InsLoadingCurtain(), Lifetime.Singleton);

  private void RegInputControls() => _di.Register<Controls>(Lifetime.Singleton);

  public void RegLocations() => _di.Register(res => res.Resolve<Assets>().Locations, Lifetime.Singleton);

  private void RegEngine() {
    new MainSystemsPack().Install(_di);
    _di.Register(_ => new EcsWorld(), Lifetime.Singleton);
    _di.Register<EventsBus>(Lifetime.Singleton);
    _di.Register<EcsEngine>(Lifetime.Singleton).AsImplementedInterfaces();
  }

  private void RegGameStateMachine() {
    _di.Register<BootstrapState>(Lifetime.Singleton).AsImplementedInterfaces();
    _di.Register<LoadLevelState>(Lifetime.Singleton).AsImplementedInterfaces();
    _di.Register<GameLoopState>(Lifetime.Singleton).AsImplementedInterfaces();

    _di.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);
  }
}