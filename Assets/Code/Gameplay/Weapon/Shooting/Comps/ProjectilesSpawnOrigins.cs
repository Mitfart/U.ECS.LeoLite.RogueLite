using System;
using System.Collections.Generic;
using Gameplay.UnityRef.Transform.Comp;

namespace Gameplay.Weapon.Shooting.Comps {
   [Serializable]
   public struct ProjectilesSpawnOrigins {
      public List<EcsTransform> value;
   }
}