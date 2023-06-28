using System.Collections.Generic;
using UnityEngine;

namespace Level {
   public partial class Room : MonoBehaviour {
      [SerializeField, HideInInspector] private Vector3      enterPoint;
      [SerializeField, HideInInspector] private Vector3[]    exitPoints;
      [SerializeField, HideInInspector] private SpawnPoint[] spawnPoints;

      public Vector3                 EnterPoint  => enterPoint;
      public IEnumerable<Vector3>    ExitPoints  => exitPoints;
      public IEnumerable<SpawnPoint> SpawnPoints => spawnPoints;
   }
}