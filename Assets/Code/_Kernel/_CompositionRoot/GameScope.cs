using Engine;
using Events;
using Infrastructure;
using Infrastructure.Loading;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using Leopotam.EcsLite;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope {
  private IContainerBuilder _di;



  protected override void Configure(IContainerBuilder di) {
    _di = di;
    RegSceneLoader();
    RegLoadingCurtain();
    RegInputControls();
    RegEngine();
    RegGameStateMachine();
  }

    
    
  private void RegSceneLoader() {
    _di.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
  }

  private void RegLoadingCurtain() {
    _di.Register<ILoadingCurtain>(_ => Instantiate(Resources.Load<LoadingCurtain>(ResourcesPath.LOADING_CURTAIN)), Lifetime.Singleton);
  }

    
  private void RegInputControls() {
    _di.Register<Controls>(Lifetime.Singleton);
  }

  private void RegEngine() {
    new MainSystemsPack().Install(_di);
    _di.Register(_ => new EcsWorld(), Lifetime.Singleton);
    _di.Register<EventsBus>(Lifetime.Singleton);
    _di.Register<IEngine, EcsEngine>(Lifetime.Singleton);
  }

  private void RegGameStateMachine() {
    _di.Register<BootstrapState>(Lifetime.Singleton).AsImplementedInterfaces();
    _di.Register<LoadLevelState>(Lifetime.Singleton).AsImplementedInterfaces();
    _di.Register<GameLoopState>(Lifetime.Singleton).AsImplementedInterfaces();

    _di.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);
  }
}