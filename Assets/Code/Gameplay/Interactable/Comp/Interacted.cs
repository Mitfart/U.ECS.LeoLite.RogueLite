using System;
using Leopotam.EcsLite;

namespace Gameplay.Interactable {
   [Serializable]
   public struct Interacted {
      public EcsPackedEntityWithWorld by;
   }
}