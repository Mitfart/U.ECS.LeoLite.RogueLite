using System;
using Infrastructure.Factories;
using UnityEngine;

namespace Gameplay.Environment.StaticData {
   [Serializable]
   public struct SpawnPoint {
      public EnemyType EnemyType;
      public Vector3   Position;
   }
}