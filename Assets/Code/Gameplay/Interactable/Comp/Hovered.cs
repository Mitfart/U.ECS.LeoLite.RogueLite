using System;
using Leopotam.EcsLite;

namespace Gameplay.Interactable {
   [Serializable]
   public struct Hovered {
      public EcsPackedEntityWithWorld By;
   }
}