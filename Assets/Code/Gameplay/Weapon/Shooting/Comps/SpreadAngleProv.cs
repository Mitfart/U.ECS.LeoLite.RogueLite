using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Structs.Ranged;
using UnityEngine;

namespace Gameplay.Weapon.Shooting.Comps {
   [DisallowMultipleComponent] public class SpreadAngleProv : EcsProvider<SpreadAngle> { }

   [Serializable]
   public struct SpreadAngle {
      [RangeEdges(min: -180f, max: 180f)] public Ranged angle;
   }
}