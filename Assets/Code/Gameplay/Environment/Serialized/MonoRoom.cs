#if UNITY_EDITOR
using Gameplay.Level.StaticData;
using TNRD.Utilities;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Level.Serialized {
   [RequireComponent(typeof(UniqueID))]
   public class MonoRoom : MonoBehaviour, ISerializationCallbackReceiver {
      private const string _ENTER_POINT_NAME            = "Enter Point";
      private const string _EXITS_CONTAINER_NAME        = "Exits";
      private const string _SPAWN_POINTS_CONTAINER_NAME = "Enemies";

      [SerializeField] private Location  location;
      [SerializeField] private RoomType  type;
      [SerializeField] private Transform enter;
      [SerializeField] private Transform exitsContainer;
      [SerializeField] private Transform spawnPointsContainer;

      [SerializeField, HideInInspector] private UniqueID uniqueID;

      private Vector3      _enterPoint;
      private Vector3[]    _exitPoints;
      private SpawnPoint[] _spawnPoints;



      public void OnBeforeSerialize() {
         uniqueID ??= GetComponent<UniqueID>();

         enter                = FindOrCreate(_ENTER_POINT_NAME,            LabelIcon.Green);
         exitsContainer       = FindOrCreate(_EXITS_CONTAINER_NAME,        LabelIcon.Blue);
         spawnPointsContainer = FindOrCreate(_SPAWN_POINTS_CONTAINER_NAME, LabelIcon.Red);

         InitEnterPoint();
         InitExitPoints();
         InitSpawnPoints();

         Store();
      }

      public void OnAfterDeserialize() { }



      private void InitEnterPoint() => _enterPoint = enter.position;

      private void InitExitPoints() {
         Transform[] transformPoints = exitsContainer.GetComponentsInChildren<Transform>();
         int         count           = transformPoints.Length - 1; // first is parent

         _exitPoints = new Vector3[count];

         for (var i = 0; i < count; i++) {
            Transform transformPoint = transformPoints[i + 1]; // first is parent => shift by 1
            _exitPoints[i] = transformPoint.position;

            transformPoint.gameObject.SetIcon(ShapeIcon.CircleBlue);
         }
      }

      private void InitSpawnPoints() {
         _spawnPoints = spawnPointsContainer.GetComponentsInChildren<SpawnPoint>();

         foreach (SpawnPoint spawnPoint in _spawnPoints) {
            spawnPoint.gameObject.SetIcon(ShapeIcon.DiamondRed);
         }
      }



      private void Store() {
         if (!location.IsUnityNull())
            location.StoreRoom(
               new Room(
                  uniqueID.ID,
                  type,
                  gameObject.scene.name,
                  _enterPoint,
                  _exitPoints,
                  _spawnPoints
               )
            );
      }


      private Transform FindOrCreate(string n, LabelIcon icon) {
         Transform container = transform.Find(n);

         if (container.IsUnityNull()) {
            container = new GameObject(n).transform;
            container.SetParent(transform);
         }

         container.gameObject.SetIcon(icon);
         return container;
      }
   }
}
#endif