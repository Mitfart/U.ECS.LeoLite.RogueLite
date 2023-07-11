using System;
using Structs.Ranged;

namespace Gameplay.Weapon.Shooting.Comps {
   [Serializable]
   public struct SpreadAngle {
      [RangeEdges(min: -180f, max: 180f)] public Ranged angle;
   }
}