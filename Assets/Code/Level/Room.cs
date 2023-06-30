using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level {
   [Serializable]
   public class Room {
      [SerializeField, HideInInspector] private string       sceneName;
      [SerializeField, HideInInspector] private Vector3      enterPoint;
      [SerializeField, HideInInspector] private Vector3[]    exitPoints;
      [SerializeField, HideInInspector] private SpawnPoint[] spawnPoints;

      public string                    SceneName   => sceneName;
      public Vector3                   EnterPoint  => enterPoint;
      public IReadOnlyList<Vector3>    ExitPoints  => exitPoints;
      public IReadOnlyList<SpawnPoint> SpawnPoints => spawnPoints;

      public Room(string sceneName, Vector3 enterPoint, Vector3[] exitPoints, SpawnPoint[] spawnPoints) {
         this.sceneName   = sceneName;
         this.enterPoint  = enterPoint;
         this.exitPoints  = exitPoints;
         this.spawnPoints = spawnPoints;
      }
   }
}