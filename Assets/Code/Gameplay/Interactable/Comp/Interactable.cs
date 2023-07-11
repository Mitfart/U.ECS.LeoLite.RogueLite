using System;
using Leopotam.EcsLite;

namespace Gameplay.Interactable {
   [Serializable]
   public struct Interactable {
      public enum State {
         Default,
         Hovered,
         Interacted
      }

      public State state;

      public EcsPackedEntityWithWorld by;
   }
}