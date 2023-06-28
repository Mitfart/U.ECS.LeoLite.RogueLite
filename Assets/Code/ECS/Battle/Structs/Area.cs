using System;
using UnityEngine;

namespace ECS.Battle.Structs {
   [Serializable]
   public struct Area {
      public Vector3 size;
      public Vector3 origin;

      public override string ToString() {
         return $"[size: {size}, origin: {origin}]";
      }
   }
}