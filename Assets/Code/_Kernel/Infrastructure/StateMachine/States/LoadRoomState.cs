using System.Linq;
using Extensions.Collections;
using Infrastructure.AssetsManagement;
using Infrastructure.Loading;
using Level;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.States {
   public class LoadRoomState : GameState, IDataRequireState<Room> {
      private readonly ISceneLoader    _sceneLoader;
      private readonly ILoadingCurtain _loadingCurtain;
      private readonly IAssets         _assets;
      private readonly Stage           _stage;
      private readonly Controls        _controls;

      private Room _room;



      public LoadRoomState(
         ISceneLoader    sceneLoader,
         ILoadingCurtain loadingCurtain,
         IAssets         assets,
         Stage           stage,
         Controls        controls
      ) {
         _sceneLoader    = sceneLoader;
         _loadingCurtain = loadingCurtain;
         _controls       = controls;
         _assets         = assets;
         _stage          = stage;
      }



      public IDataRequireState<Room> SetData(Room data) {
         _room = data;
         return this;
      }

      public override void Enter() {
         _controls.Disable();

         _loadingCurtain.Show();

         LoadRoom();
      }

      public override void Exit() => _loadingCurtain.Hide();



      private void LoadRoom() => _sceneLoader.Load(_room.SceneName, OnLoaded);

      private void OnLoaded(Scene scene) {
         SpawnEnemies(_room);
         SpawnPlayer(_room);
         CreateDoors(_room);

         StateMachine.Enter<GameLoopState>();
      }



      private void SpawnEnemies(Room room) {
         foreach (SpawnPoint spawnPoint in room.SpawnPoints) {
            SpawnEnemy(spawnPoint);
         }
      }

      private void SpawnPlayer(Room room) {
         GameObject player = _assets.Ins<GameObject>(AssetPath.PLAYER);
         player.transform.position = room.EnterPoint;
      }

      private void CreateDoors(Room room) {
         foreach (Vector3 exitPoint in room.ExitPoints) {
            Door door = _assets.Ins<Door>(AssetPath.DOOR, exitPoint);

            Location nextLocation = _stage.Location;
            Room     nextRoom     = nextLocation.DefaultRooms.Random(_stage.PassedRooms.ToArray());

            door.Construct(
               nextLocation,
               nextRoom
            );
         }
      }



      private void SpawnEnemy(SpawnPoint spawnPoint) {
         ConvertToEntity enemy = _assets.Ins(spawnPoint.Enemy);
         enemy.transform.position = spawnPoint.Position;
      }
   }
}