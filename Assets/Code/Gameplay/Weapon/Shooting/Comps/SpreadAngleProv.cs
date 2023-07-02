using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Structs.Ranged;
using UnityEngine;

namespace Weapon.Shooting {
   [DisallowMultipleComponent] public class SpreadAngleProv : EcsProvider<SpreadAngle> { }

   [Serializable]
   public struct SpreadAngle {
      [RangeEdges(min: -180f, max: 180f)] public Ranged angle;
   }
}