using System.Collections.Generic;
using System.Linq;
using TNRD.Utilities;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Level.StaticData.Serialized {
   public class MonoRoom : MonoBehaviour, ISerializationCallbackReceiver {
#if UNITY_EDITOR
      private const string _ENTER_POINT_NAME            = "Enter Point";
      private const string _EXITS_CONTAINER_NAME        = "Exits";
      private const string _SPAWN_POINTS_CONTAINER_NAME = "Enemies";

      [SerializeField] private Location  location;
      [SerializeField] private RoomType  type;
      [SerializeField] private Transform enter;
      [SerializeField] private Transform exitsContainer;
      [SerializeField] private Transform spawnPointsContainer;

      [SerializeField, HideInInspector] private UniqueID uniqueID;

      private Vector3                 _enterPoint;
      private IEnumerable<Vector3>    _exitPoints;
      private IEnumerable<SpawnPoint> _spawnPoints;



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

      private void InitExitPoints()
         => _exitPoints =
            exitsContainer
              .GetComponentsInChildren<MonoExit>()
              .Select(
                  exit => {
                     exit.gameObject.SetIcon(ShapeIcon.CircleBlue);
                     return exit.Position;
                  }
               );

      private void InitSpawnPoints()
         => _spawnPoints =
            spawnPointsContainer
              .GetComponentsInChildren<MonoSpawnPoint>()
              .Select(
                  point => {
                     point.gameObject.SetIcon(ShapeIcon.DiamondRed);
                     return point.spawnPoint;
                  }
               );



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
#endif
   }
}