using Engine;
using Extensions.Collections;
using Gameplay.Environment;
using Gameplay.Environment.StaticData;
using Infrastructure.Factories;
using Infrastructure.Factories.Extensions;
using Infrastructure.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.States {
   public class LoadLevelState : GameState, IDataRequireState<NextLevel> {
      private readonly ISceneLoader       _sceneLoader;
      private readonly ILoadingCurtain    _loadingCurtain;
      private readonly EnemyFactory       _enemyFactory;
      private readonly PlayerFactory      _playerFactory;
      private readonly EnvironmentFactory _environmentFactory;
      private readonly Level              _level;
      private readonly Controls           _controls;
      private readonly IEngine            _engine;

      private NextLevel _nextLevel;

      private Location NextLocation => _nextLevel.Location;
      private Room     NextRoom     => _nextLevel.Room;



      public LoadLevelState(
         IGameStateMachine  stateMachine,
         ISceneLoader       sceneLoader,
         ILoadingCurtain    loadingCurtain,
         EnemyFactory       enemyFactory,
         PlayerFactory      playerFactory,
         EnvironmentFactory environmentFactory,
         Level              level,
         Controls           controls,
         IEngine            engine
      ) : base(stateMachine) {
         _sceneLoader        = sceneLoader;
         _loadingCurtain     = loadingCurtain;
         _enemyFactory       = enemyFactory;
         _playerFactory      = playerFactory;
         _environmentFactory = environmentFactory;
         _controls           = controls;
         _engine             = engine;
         _level              = level;
      }



      public IDataRequireState<NextLevel> SetData(NextLevel data) {
         _nextLevel = data;

         UpdateCurrentLevel();
         return this;
      }

      public override void Enter() {
         _controls.Disable();
         _engine.Disable();

         _loadingCurtain.Show();

         LoadRoom();
      }

      public override void Exit() {
         _loadingCurtain.Hide();
      }



      private void LoadRoom() {
         _sceneLoader.Load(NextRoom.SceneName, OnLoaded);
      }

      private void OnLoaded(Scene _) {
         SpawnEnemies();
         SpawnPlayer();
         CreateDoors();

         StateMachine.Enter<GameLoopState>();
      }



      private void UpdateCurrentLevel() {
         if (NewLocation())
            _level.SetLocation(NextLocation);

         _level.SetRoom(NextRoom);


         bool NewLocation() => NextLocation != _level.Location;
      }



      private void SpawnEnemies() {
         foreach (SpawnPoint spawn in NextRoom.SpawnPoints)
            _enemyFactory.Spawn(
               spawn.EnemyType,
               at: spawn.Position
            );
      }

      private void SpawnPlayer() {
         _playerFactory.Spawn(
            NextRoom.EnterPoint
         );
      }

      private void CreateDoors() {
         foreach (Vector3 exitPoint in NextRoom.ExitPoints)
            _environmentFactory.CreateDoor(
               exitPoint,
               _level.Location,
               _level.Location.DefaultRooms.Random( /*_level.PassedRooms.ToArray()*/)
            );
      }
   }
}