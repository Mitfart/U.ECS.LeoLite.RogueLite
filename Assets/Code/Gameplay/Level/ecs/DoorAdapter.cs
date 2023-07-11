using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Level.ecs.tmp.Comp {
   [DisallowMultipleComponent]
   public class DoorAdapter : EcsAdapter<Door> {
      public override void Convert() {
         base.Convert();
         Set<Interactable.Interactable>();
      }
   }
}