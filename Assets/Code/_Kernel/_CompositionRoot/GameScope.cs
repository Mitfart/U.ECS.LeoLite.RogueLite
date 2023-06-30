using Debug;
using Engine;
using Events;
using Extensions.VContainer;
using Infrastructure.AssetsManagement;
using Infrastructure.Loading;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using Leopotam.EcsLite;
using Level;
using VContainer;
using VContainer.Unity;
using View;

public class GameScope : LifetimeScope {
   private IContainerBuilder _di;



   protected override void Configure(IContainerBuilder di) {
      _di = di;

      RegSceneLoader();
      RegInputControls();

      RegAssets();
      RegGizmosService();
      RegRender();
      RegLoadingCurtain();

      RegStage();
      RegLocation();

      RegEngine();

      RegGameStateMachine();
   }



   private void RegSceneLoader()   => _di.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
   private void RegInputControls() => _di.Register<Controls>(Lifetime.Singleton);
   private void RegAssets()        => _di.Register<IAssets, Assets>(Lifetime.Singleton);

   private void RegGizmosService()  => _di.RegPrefabInstance<GizmosService>(AssetPath.GIZMOS_SERVICE);
   private void RegRender()         => _di.RegPrefabInstance<Render>(AssetPath.RENDER);
   private void RegLoadingCurtain() => _di.RegPrefabInstance<LoadingCurtain>(AssetPath.LOADING_CURTAIN);

   private void RegStage()    => _di.Register<Stage>(Lifetime.Singleton);
   private void RegLocation() => _di.RegScriptable<Location>(AssetPath.START_LOCATION);

   private void RegEngine() {
      new MainSystemsPack().Install(_di);
      _di.Register(_ => new EcsWorld(), Lifetime.Singleton);
      _di.Register<EventsBus>(Lifetime.Singleton);
      _di.Register<IEngine, EcsEngine>(Lifetime.Singleton);
   }

   private void RegGameStateMachine() {
      Reg<BootstrapState>();
      Reg<SetupGameState>();
      Reg<LoadRoomState>();
      Reg<GameLoopState>();

      _di.RegisterEntryPoint<GameStateMachine>();


      void Reg<TState>() where TState : IGameState {
         _di.Register<IGameState, TState>(Lifetime.Singleton);
      }
   }
}