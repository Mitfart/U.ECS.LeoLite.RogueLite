using Leopotam.EcsLite;

namespace Gameplay.Player.Sys {
   public class ResetInteractablesSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Interactable.Interactable> _interactablePool;



      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<Interactable.Interactable>().End();

         _interactablePool = _world.GetPool<Interactable.Interactable>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            ref Interactable.Interactable interactable = ref _interactablePool.Get(e);

            interactable.state = Interactable.Interactable.State.Default;
            interactable.by    = default;
         }
      }
   }
}