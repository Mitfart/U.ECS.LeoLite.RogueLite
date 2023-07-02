using Extensions.Ecs;
using Gameplay.Interactable;
using Leopotam.EcsLite;

namespace Gameplay.Player.Sys {
   public class InteractSys : IEcsRunSystem, IEcsInitSystem {
      private readonly Controls _controls;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Interacted> _interactedPool;
      private EcsPool<Hovered>    _hoveredPool;



      public InteractSys(Controls controls) {
         _controls = controls;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<Interactable.Interactable>()
                         .Inc<Hovered>()
                         .End();

         _interactedPool = _world.GetPool<Interacted>();
         _hoveredPool    = _world.GetPool<Hovered>();
      }

      public void Run(IEcsSystems systems) {
         if (!_controls.Game.Interact.triggered)
            return;

         foreach (int e in _filter)
            _interactedPool.Set(e).by = _hoveredPool.Get(e).by;
      }
   }
}