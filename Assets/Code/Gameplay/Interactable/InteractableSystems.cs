using Engine.Ecs;
using Extensions.Ecs;
using Gameplay.Interactable.Sys;

namespace Gameplay.Interactable {
   public class InteractableSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<DelHereSys<Hovered>>();
         Add<HoverInteractableInRadius>();
      }
   }
}