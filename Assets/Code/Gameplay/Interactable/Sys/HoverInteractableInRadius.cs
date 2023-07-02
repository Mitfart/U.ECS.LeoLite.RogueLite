using Extensions.Ecs;
using Leopotam.EcsLite;
using Player;
using UnityEngine;
using UnityRef;

namespace Gameplay.Interactable.Sys {
   public class HoverInteractableInRadius : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld _world;

      private EcsFilter _interactableFilter;
      private EcsFilter _playerFilter;

      private EcsPool<Interactable> _interactablePool;
      private EcsPool<EcsTransform> _ecsTransformPool;
      private EcsPool<Hovered>      _hoveredPool;



      public void Run(IEcsSystems systems) {
         foreach (int playerE in _playerFilter) {
            ref EcsTransform playerT = ref _ecsTransformPool.Get(playerE);

            int   closestInteractableE = -1;
            float closestDistance      = float.MaxValue;

            foreach (int interactableE in _interactableFilter) {
               ref EcsTransform interactableT = ref _ecsTransformPool.Get(interactableE);
               ref Interactable interactable  = ref _interactablePool.Get(interactableE);

               if (closestDistance <= interactable.radius)
                  continue;

               float distance = Vector2.Distance(interactableT.Position, playerT.Position);

               if (distance > interactable.radius
                || distance >= closestDistance)
                  continue;

               closestDistance      = distance;
               closestInteractableE = interactableE;
            }

            if (closestInteractableE >= 0)
               _hoveredPool.TryAdd(closestInteractableE);
         }
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();

         _interactableFilter = _world.Filter<Interactable>().End();
         _playerFilter       = _world.Filter<PlayerTag>().End();

         _interactablePool = _world.GetPool<Interactable>();
         _ecsTransformPool = _world.GetPool<EcsTransform>();
         _hoveredPool      = _world.GetPool<Hovered>();
      }
   }
}