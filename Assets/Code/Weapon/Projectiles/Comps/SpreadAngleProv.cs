using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Structs.Ranged;
using UnityEngine;

namespace Weapon.Projectiles {
  [DisallowMultipleComponent] public class SpreadAngleProv : EcsProvider<SpreadAngle> { }

  [Serializable]
  public struct SpreadAngle {
    [RangeEdges(-180f, 180f)] public Ranged angle;
  }
}