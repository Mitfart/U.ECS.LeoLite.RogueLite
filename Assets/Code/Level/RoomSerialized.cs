#if UNITY_EDITOR
using TNRD.Utilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Level {
  public partial class Room : ISerializationCallbackReceiver {
    private const string ENTER_POINT_NAME            = "Enter Point";
    private const string EXITS_CONTAINER_NAME        = "Exits";
    private const string SPAWN_POINTS_CONTAINER_NAME = "Enemies";

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
      if (!enter.IsUnityNull())
        return;

      enter = new GameObject(ENTER_POINT_NAME);
      enter.transform.SetParent(transform);
    }

    private void CreateExitsContainer() {
      if (!exitsContainer.IsUnityNull())
        return;

      exitsContainer = new GameObject(EXITS_CONTAINER_NAME);
      exitsContainer.transform.SetParent(transform);
    }

    private void CreateSpawnPointsContainer() {
      if (!spawnPointsContainer.IsUnityNull())
        return;

      spawnPointsContainer = new GameObject(SPAWN_POINTS_CONTAINER_NAME);
      spawnPointsContainer.transform.SetParent(transform);
    }



    public void InitEnterPoint() {
      enterPoint = enter.transform.position;

      enter.SetIcon(ShapeIcon.CircleGreen);
    }

    public void InitExitPoints() {
      Transform[] transformPoints = exitsContainer.GetComponentsInChildren<Transform>();

      exitPoints = new Vector3[transformPoints.Length];


      for (var i = 0; i < transformPoints.Length; i++) {
        Transform transformPoint = transformPoints[i];
        exitPoints[i] = transformPoint.position;

        transformPoint.gameObject.SetIcon(ShapeIcon.CircleBlue);
      }

      exitsContainer.SetIcon(LabelIcon.Blue);
    }

    public void InitSpawnPoints() {
      spawnPoints = spawnPointsContainer.GetComponentsInChildren<SpawnPoint>();

      foreach (SpawnPoint spawnPoint in spawnPoints) {
        spawnPoint.gameObject.SetIcon(ShapeIcon.DiamondRed);
      }

      spawnPointsContainer.SetIcon(LabelIcon.Red);
    }
  }
}
#endif