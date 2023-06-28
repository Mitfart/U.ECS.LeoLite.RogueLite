using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace ECS.Weapon.Aim {
   [DisallowMultipleComponent] public class AimPositionProv : EcsProvider<AimPosition> { }

   [Serializable]
   public struct AimPosition {
      public Vector3 value;
   }
}