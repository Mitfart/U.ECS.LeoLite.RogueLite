using Extensions.Ecs;
using Gameplay.Player.Sys;

namespace Gameplay.Interactable {
   public class InteractableSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<ResetInteractablesSys>();
         Add<HoverInteractableSys>();
         Add<InteractSys>();
      }
   }
}