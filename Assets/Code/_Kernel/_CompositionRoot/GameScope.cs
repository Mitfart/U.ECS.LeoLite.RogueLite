using System.Collections.Generic;
using Debug;
using Engine;
using Events;
using Gameplay.Environment;
using Infrastructure.AssetsManagement;
using Infrastructure.AssetsManagement.VContainerExtensions;
using Infrastructure.Factories;
using Infrastructure.Factories.Extensions;
using Infrastructure.Loading;
using Infrastructure.Render;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using Leopotam.EcsLite;
using VContainer;
using VContainer.Unity;

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

      RegLevel();

      RegFactories();

      RegEngine();

      RegGameStateMachine();
      RegStates();
   }



   private void RegSceneLoader()   => _di.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
   private void RegInputControls() => _di.Register<Controls>(Lifetime.Singleton);
   private void RegAssets()        => _di.Register<IAssets, Assets>(Lifetime.Singleton);

   private void RegGizmosService()  => _di.RegInstanceInstantly<GizmosService>(AssetPath.GIZMOS_SERVICE);
   private void RegRender()         => _di.RegInstanceInstantly<Render>(AssetPath.RENDER);
   private void RegLoadingCurtain() => _di.RegInstanceInstantly<LoadingCurtain>(AssetPath.LOADING_CURTAIN);


   private void RegLevel() => _di.Register<Level>(Lifetime.Singleton);


   private void RegFactories() {
      _di.Register<EnvironmentFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
      _di.Register<EnemyFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
      _di.Register<PlayerFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
   }


   private void RegEngine() {
      new MainSystemsPack().Install(_di);
      _di.Register(_ => new EcsWorld(), Lifetime.Singleton);
      _di.Register<EventsBus>(Lifetime.Singleton);
      _di.RegisterEntryPoint<EcsEngine>();
   }


   private void RegGameStateMachine() {
      _di.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);
      _di.RegisterBuildCallback(
         resolver =>
            resolver
              .Resolve<IGameStateMachine>()
              .RegisterStates(
                  resolver.Resolve<IReadOnlyList<IGameState>>()
               )
      );
   }

   private void RegStates() {
      Reg<BootstrapState>();
      Reg<SetupGameState>();
      Reg<LoadLevelState>();
      Reg<GameLoopState>();


      void Reg<TState>() where TState : IGameState {
         _di.Register<IGameState, TState>(Lifetime.Singleton);
      }
   }
}