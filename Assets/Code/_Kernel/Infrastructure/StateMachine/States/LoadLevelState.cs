using System.Linq;
using Engine;
using Extensions.Collections;
using Gameplay.Level;
using Gameplay.Level.StaticData;
using Infrastructure.AssetsManagement;
using Infrastructure.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.States {
   public class LoadLevelState : GameState, IDataRequireState<NextLevel> {
      private readonly ISceneLoader    _sceneLoader;
      private readonly ILoadingCurtain _loadingCurtain;
      private readonly IAssets         _assets;
      private readonly Level           _level;
      private readonly Controls        _controls;
      private readonly IEngine         _engine;

      private NextLevel _nextLevel;

      private Location NextLocation => _nextLevel.Location;
      private Room     NextRoom     => _nextLevel.Room;



      public LoadLevelState(
         ISceneLoader    sceneLoader,
         ILoadingCurtain loadingCurtain,
         IAssets         assets,
         Level           level,
         Controls        controls,
         IEngine         engine
      ) {
         _sceneLoader    = sceneLoader;
         _loadingCurtain = loadingCurtain;
         _controls       = controls;
         _engine         = engine;
         _assets         = assets;
         _level          = level;
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
         foreach (SpawnPoint spawnPoint in NextRoom.SpawnPoints)
            _assets.Ins(
               spawnPoint.Enemy,
               at: spawnPoint.Position
            );
      }

      private void SpawnPlayer() {
         _assets.Ins<GameObject>(
            AssetPath.PLAYER,
            at: NextRoom.EnterPoint
         );
      }

      private void CreateDoors() {
         foreach (Vector3 exitPoint in NextRoom.ExitPoints) {
            DoorProv doorIns = _assets.Ins<DoorProv>(
               AssetPath.DOOR,
               at: exitPoint
            );

            doorIns.component.NextLevel
               = new NextLevel(
                  _level.Location,
                  _level.Location.DefaultRooms.Random(_level.PassedRooms.ToArray())
               );
         }
      }
   }
}