using System;
using Leopotam.EcsLite;

namespace Gameplay.Unit.Behavior.ECS.Comps {
   [Serializable]
   public struct Target {
      public EcsPackedEntityWithWorld Value;
   }
}