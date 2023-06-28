using System;
using Infrastructure.AssetsManagement;
using Infrastructure.Loading;
using Level;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.States {
   public class LoadRoomState : GameState, IDataRequireState<string> {
      private readonly ISceneLoader    _sceneLoader;
      private readonly ILoadingCurtain _loadingCurtain;
      private readonly IAssets         _assets;
      private readonly Controls        _controls;

      private string _roomSceneName;



      public LoadRoomState(
         ISceneLoader    sceneLoader,
         ILoadingCurtain loadingCurtain,
         IAssets         assets,
         Controls        controls
      ) {
         _sceneLoader    = sceneLoader;
         _loadingCurtain = loadingCurtain;
         _controls       = controls;
         _assets         = assets;
      }

      public IDataRequireState<string> SetData(string roomSceneName) {
         _roomSceneName = roomSceneName;
         return this;
      }



      public override void Enter() {
         _controls.Disable();

         _loadingCurtain.Show();

         LoadRoom();
      }

      public override void Exit() {
         _loadingCurtain.Hide();
      }



      private void LoadRoom() {
         _sceneLoader.Load(_roomSceneName, OnLoaded);
      }

      private void OnLoaded(Scene scene) {
         Room room = GetRoom(scene);

         SpawnEnemies(room);
         SpawnPlayer(room);
         CreateDoors(room);
         
         StateMachine.Enter<GameLoopState>();
      }



      private Room GetRoom(Scene scene) {
         foreach (GameObject go in scene.GetRootGameObjects())
            if (go.TryGetComponent(out Room room))
               return room;

         throw new Exception($"Can't find <{nameof(Room)}> component at the room of {_roomSceneName}");
      }

      private void SpawnEnemies(Room room) {
         foreach (SpawnPoint spawnPoint in room.SpawnPoints) 
            SpawnEnemy(spawnPoint);
      }

      private void SpawnPlayer(Room room) {
         GameObject player = _assets.Ins<GameObject>(AssetPath.PLAYER);
         player.transform.position = room.EnterPoint;
      }

      private void CreateDoors(Room room) {
         foreach (Vector3 exitPoint in room.ExitPoints) {
            GameObject door = _assets.Ins<GameObject>(AssetPath.DOOR);
            door.transform.position = exitPoint;
         }
      }

      
      
      private void SpawnEnemy(SpawnPoint spawnPoint) {
         ConvertToEntity enemy = _assets.Ins(spawnPoint.Enemy);
         enemy.transform.position = spawnPoint.Position;
      }
   }
}