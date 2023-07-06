using System;
using Infrastructure.Factories;
using UnityEngine;

namespace Gameplay.Level.StaticData {
   [Serializable]
   public struct SpawnPoint {
      public EnemyType enemyType;
      public Vector3   position;
   }
}