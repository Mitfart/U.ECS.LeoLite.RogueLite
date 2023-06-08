using Engine;
using Events;
using VContainer;
using VContainer.Unity;

namespace Code._Kernel {
  public class GameScope : LifetimeScope {
    private IContainerBuilder _di;

    protected override void Configure(IContainerBuilder di) {
      _di = di;
      RegDI();

      RegSceneLoader();
      BindInputControls();
      BindEngine();
      BindGameStateMachine();

      UnityEngine.Debug.Log("AUTO START ENGINE");
      _di.RegisterBuildCallback(res => res.Resolve<IEngine>());
    }

    private void RegDI() {
      _di.Register(_ => _di, Lifetime.Singleton);
    }



    private void RegSceneLoader() {
      /*
      _di
        .Bind<ISceneLoader>()
        .To<SceneLoader>()
        .AsSingle();
      */
    }

    private void BindInputControls() {
      /*
      Container.Bind<Controls>().AsSingle();
      */
    }

    private void BindEngine() {
      new MainSystemsPack().Install(_di);
      _di.Register<EventsBus>(Lifetime.Singleton);
      _di.Register<IEngine, EcsEngine>(Lifetime.Singleton);
    }

    private void BindGameStateMachine() {
      /*
      Container.Bind<BootstrapState>().AsSingle();
      Container.Bind<LoadLevelState>().AsSingle();
      Container.Bind<GameLoopState>().AsSingle();
      Container.Bind<FinishSessionState>().AsSingle();

      Container
       .Bind<IGameStateMachine>()
       .To<GameStateMachine>()
       .AsSingle();
      */
    }
  }
}