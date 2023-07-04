using _Lab;
using Engine.Ecs;
using Extensions.Ecs;
using Gameplay.Interactable;
using Gameplay.Player.Sys;

namespace Gameplay.Player {
   public class PlayerSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<DelHereSys<Hovered>>();
         Add<DelHereSys<Interacted>>();
         Add<HoverInteractableInRadius>();
         Add<InteractSys>();

         Add<MovementInputSys>();
         Add<TestPlayerInputSys>();
      }
   }
}