#if UNITY_EDITOR
using TNRD.Utilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Level {
   public partial class Room : ISerializationCallbackReceiver {
      private const string _ENTER_POINT_NAME            = "Enter Point";
      private const string _EXITS_CONTAINER_NAME        = "Exits";
      private const string _SPAWN_POINTS_CONTAINER_NAME = "Enemies";

      [SerializeField] private GameObject enter;
      [SerializeField] private GameObject exitsContainer;
      [SerializeField] private GameObject spawnPointsContainer;



      public void OnBeforeSerialize() {
         CreateEnterPoint();
         CreateExitsContainer();
         CreateSpawnPointsContainer();

         InitEnterPoint();
         InitExitPoints();
         InitSpawnPoints();

         EditorUtility.SetDirty(this);
      }

      public void OnAfterDeserialize() { }



      private void CreateEnterPoint() {
         if (!enter.IsUnityNull()) return;

         enter = new GameObject(_ENTER_POINT_NAME);
         enter.transform.SetParent(transform);
      }

      private void CreateExitsContainer() {
         if (!exitsContainer.IsUnityNull()) return;

         exitsContainer = new GameObject(_EXITS_CONTAINER_NAME);
         exitsContainer.transform.SetParent(transform);
      }

      private void CreateSpawnPointsContainer() {
         if (!spawnPointsContainer.IsUnityNull()) return;

         spawnPointsContainer = new GameObject(_SPAWN_POINTS_CONTAINER_NAME);
         spawnPointsContainer.transform.SetParent(transform);
      }



      private void InitEnterPoint() {
         enterPoint = enter.transform.position;

         enter.SetIcon(ShapeIcon.CircleGreen);
      }

      private void InitExitPoints() {
         Transform[] transformPoints = exitsContainer.GetComponentsInChildren<Transform>();
         int         count           = transformPoints.Length - 1; // first is parent

         exitPoints = new Vector3[count];
         
         for (var i = 0; i < count; i++) {
            Transform transformPoint = transformPoints[i + 1]; // first is parent => shift by 1
            exitPoints[i] = transformPoint.position;

            transformPoint.gameObject.SetIcon(ShapeIcon.CircleBlue);
         }

         exitsContainer.SetIcon(LabelIcon.Blue);
      }

      private void InitSpawnPoints() {
         spawnPoints = spawnPointsContainer.GetComponentsInChildren<SpawnPoint>();

         foreach (SpawnPoint spawnPoint in spawnPoints) {
            spawnPoint.gameObject.SetIcon(ShapeIcon.DiamondRed);
         }

         spawnPointsContainer.SetIcon(LabelIcon.Red);
      }
   }
}
#endif