﻿using System.Collections.Generic;
using Engine;
using Events;
using Gameplay.Level;
using Gameplay.Unit.Behavior;
using Infrastructure.AssetsManagement;
using Infrastructure.AssetsManagement.VContainerExtensions;
using Infrastructure.Factories;
using Infrastructure.Factories.Projectiles;
using Infrastructure.Loading;
using Infrastructure.Render;
using Infrastructure.Services.Gizmos;
using Infrastructure.Services.Time;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using Leopotam.EcsLite;
using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope {
   private IContainerBuilder _di;



   protected override void Configure(IContainerBuilder di) {
      _di = di;

      RegTimeService();
      RegSceneLoader();
      RegInputControls();

      RegAssets();
      RegGizmosService();
      RegRender();
      RegLoadingCurtain();

      RegAINavService();
      RegLevel();

      RegFactories();

      RegEngine();

      RegGameStateMachine();
      RegStates();
   }



   private void RegTimeService()   => _di.Register<ITimeService, TimeService>(Lifetime.Singleton);
   private void RegSceneLoader()   => _di.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
   private void RegInputControls() => _di.Register<Controls>(Lifetime.Singleton);
   private void RegAssets()        => _di.Register<IAssets, Assets>(Lifetime.Singleton);

   private void RegGizmosService()  => _di.RegInstanceInstantly<GizmosService>(AssetPath.GIZMOS_SERVICE);
   private void RegRender()         => _di.RegInstanceInstantly<Render>(AssetPath.RENDER);
   private void RegLoadingCurtain() => _di.RegInstanceInstantly<LoadingCurtain>(AssetPath.LOADING_CURTAIN);


   private void RegAINavService() => _di.RegInstanceInstantly<AINavService>(AssetPath.AI_NAV_SERVICE);
   private void RegLevel()        => _di.Register<Level>(Lifetime.Singleton);


   private void RegFactories() {
      _di.Register<EnvironmentFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
      _di.Register<EnemyFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
      _di.Register<PlayerFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
      _di.Register<ProjectilesFactory>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
   }


   private void RegEngine() {
      _di.Register(_ => new EcsWorld(), Lifetime.Singleton);

      _di.Register<EventsBus>(Lifetime.Singleton);

      new MainSystemsPack().Install(_di);
      _di.Register<EngineSystems>(Lifetime.Singleton).AsImplementedInterfaces();
      _di.Register<EcsEngine>(Lifetime.Singleton).AsImplementedInterfaces();
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