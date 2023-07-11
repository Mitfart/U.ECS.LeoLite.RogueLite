using Leopotam.EcsLite;

namespace Gameplay.Player.Sys {
   public class InteractSys : IEcsRunSystem, IEcsInitSystem {
      private readonly Controls _controls;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Interactable.Interactable> _interactablePool;



      public InteractSys(Controls controls) {
         _controls = controls;
      }

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<Interactable.Interactable>().End();

         _interactablePool = _world.GetPool<Interactable.Interactable>();
      }

      public void Run(IEcsSystems systems) {
         if (!_controls.Game.Interact.triggered)
            return;

         foreach (int e in _filter)
            _interactablePool.Get(e).state = Interactable.Interactable.State.Interacted;
      }
   }
}