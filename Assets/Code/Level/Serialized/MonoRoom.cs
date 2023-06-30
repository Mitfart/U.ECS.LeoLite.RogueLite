#if UNITY_EDITOR
using TNRD.Utilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Level {
   public class MonoRoom : MonoBehaviour, ISerializationCallbackReceiver {
      private const string _ENTER_POINT_NAME            = "Enter Point";
      private const string _EXITS_CONTAINER_NAME        = "Exits";
      private const string _SPAWN_POINTS_CONTAINER_NAME = "Enemies";

      [SerializeField] private Transform enter;
      [SerializeField] private Transform exitsContainer;
      [SerializeField] private Transform spawnPointsContainer;

      [SerializeField, HideInInspector] private Room room;

      private Vector3      _enterPoint;
      private Vector3[]    _exitPoints;
      private SpawnPoint[] _spawnPoints;



      public void OnBeforeSerialize() {
         enter                = FindOrCreate(_ENTER_POINT_NAME);
         exitsContainer       = FindOrCreate(_EXITS_CONTAINER_NAME);
         spawnPointsContainer = FindOrCreate(_SPAWN_POINTS_CONTAINER_NAME);

         InitEnterPoint();
         InitExitPoints();
         InitSpawnPoints();

         room = new Room(
            gameObject.scene.name,
            _enterPoint,
            _exitPoints,
            _spawnPoints
         );

         EditorUtility.SetDirty(this);
      }

      public void OnAfterDeserialize() { }



      private void InitEnterPoint() {
         _enterPoint = enter.position;

         enter.gameObject.SetIcon(ShapeIcon.CircleGreen);
      }
      
      private void InitExitPoints() {
         Transform[] transformPoints = exitsContainer.GetComponentsInChildren<Transform>();
         int         count           = transformPoints.Length - 1; // first is parent

         _exitPoints = new Vector3[count];

         for (var i = 0; i < count; i++) {
            Transform transformPoint = transformPoints[i + 1]; // first is parent => shift by 1
            _exitPoints[i] = transformPoint.position;

            transformPoint.gameObject.SetIcon(ShapeIcon.CircleBlue);
         }

         exitsContainer.gameObject.SetIcon(LabelIcon.Blue);
      }

      private void InitSpawnPoints() {
         _spawnPoints = spawnPointsContainer.GetComponentsInChildren<SpawnPoint>();

         foreach (SpawnPoint spawnPoint in _spawnPoints) {
            spawnPoint.gameObject.SetIcon(ShapeIcon.DiamondRed);
         }

         spawnPointsContainer.gameObject.SetIcon(LabelIcon.Red);
      }



      private Transform FindOrCreate(string n) {
         Transform container = transform.Find(n);

         if (container.IsUnityNull()) {
            container = new GameObject(n).transform;
            container.SetParent(transform);
         }
         
         return container;
      }
   }
}
#endif