using Extensions.Ecs;
using Gameplay.Interactable;
using Gameplay.Player.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Player.Sys {
   public class HoverInteractableInRadius : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld _world;

      private EcsFilter _playerFilter;
      private EcsFilter _interactableFilter;

      private EcsPool<InteractRadius> _interactRadiusPool;
      private EcsPool<EcsTransform>   _ecsTransformPool;
      private EcsPool<Hovered>        _hoveredPool;



      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();

         _playerFilter       = _world.Filter<PlayerTag>().Inc<InteractRadius>().End();
         _interactableFilter = _world.Filter<Interactable.Interactable>().End();

         _interactRadiusPool = _world.GetPool<InteractRadius>();
         _ecsTransformPool   = _world.GetPool<EcsTransform>();
         _hoveredPool        = _world.GetPool<Hovered>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int playerE in _playerFilter) {
            if (ClosestInteractable(InteractableRadius(playerE), playerE, out int closestInteractableE))
               SetHovered(closestInteractableE, playerE);
         }
      }



      private float InteractableRadius(int playerE) => _interactRadiusPool.Get(playerE).value;

      private bool ClosestInteractable(float radius, int e, out int entity) {
         float closestDistance = radius;
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

      private void SetHovered(int entity, int by) => _hoveredPool.Set(entity).By = _world.PackEntityWithWorld(by);
   }
}