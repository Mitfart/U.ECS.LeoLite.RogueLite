using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Environment.StaticData {
   [Serializable]
   public class Room {
      [SerializeField] private string       id;
      [SerializeField] private RoomType     type;
      [SerializeField] private string       sceneName;
      [SerializeField] private Vector3      enterPoint;
      [SerializeField] private Vector3[]    exitPoints;
      [SerializeField] private SpawnPoint[] spawnPoints;

      public string                    ID          => id;
      public RoomType                  RoomType    => type;
      public string                    SceneName   => sceneName;
      public Vector3                   EnterPoint  => enterPoint;
      public IReadOnlyList<Vector3>    ExitPoints  => exitPoints;
      public IReadOnlyList<SpawnPoint> SpawnPoints => spawnPoints;

      public Room(
         string                  id,
         RoomType                type,
         string                  sceneName,
         Vector3                 enterPoint,
         IEnumerable<Vector3>    exitPoints,
         IEnumerable<SpawnPoint> spawnPoints
      ) {
         this.id          = id;
         this.type        = type;
         this.sceneName   = sceneName;
         this.enterPoint  = enterPoint;
         this.exitPoints  = exitPoints.ToArray();
         this.spawnPoints = spawnPoints.ToArray();
      }
   }
}