using Extensions.Ecs;
using Gameplay.Player.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Player.Sys {
   public class HoverInteractableSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld _world;

      private EcsFilter _interactorFilter;
      private EcsFilter _interactableFilter;

      private EcsPool<Interactor>                _interactorPool;
      private EcsPool<Interactable.Interactable> _interactablePool;
      private EcsPool<EcsTransform>              _ecsTransformPool;



      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();

         _interactorFilter   = _world.Filter<Interactor>().End();
         _interactableFilter = _world.Filter<Interactable.Interactable>().End();

         _interactorPool   = _world.GetPool<Interactor>();
         _interactablePool = _world.GetPool<Interactable.Interactable>();
         _ecsTransformPool = _world.GetPool<EcsTransform>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int interactorE in _interactorFilter)
            if (ClosestInteractable(interactorE, out int closestInteractableE))
               SetHovered(closestInteractableE, interactorE);
      }



      private bool ClosestInteractable(int e, out int entity) {
         float closestDistance = InteractableRadius(e);
         entity = -1;

         foreach (int interactableE in _interactableFilter) {
            float distance = DistanceBetween(e, interactableE);

            if (distance >= closestDistance)
               continue;

            closestDistance = distance;
            entity          = interactableE;
         }

         return entity.IsAlive(_world);
      }

      private float DistanceBetween(int e1, int e2)
         => Vector2.Distance(
            _ecsTransformPool.Get(e1).Position,
            _ecsTransformPool.Get(e2).Position
         );

      private float InteractableRadius(int playerE) => _interactorPool.Get(playerE).radius;

      private void SetHovered(int entity, int by) {
         ref Interactable.Interactable interactable = ref _interactablePool.Get(entity);

         interactable.state = Interactable.Interactable.State.Hovered;
         interactable.by    = _world.PackEntityWithWorld(by);
      }
   }
}