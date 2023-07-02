using Debug;
using Events;
using Gameplay.HitBoxes.Comps;
using Gameplay.HitBoxes.Extensions;
using Leopotam.EcsLite;

namespace Gameplay.HitBoxes.Debug {
   public class HitEventDebugSys : IEcsRunSystem, IEcsInitSystem {
      private readonly GizmosService _gizmosService;
      private readonly EventsBus     _eventsBus;

      private EcsWorld _world;



      public HitEventDebugSys(GizmosService gizmosService, EventsBus eventsBus) {
         _gizmosService = gizmosService;
         _eventsBus     = eventsBus;
      }

      public void Init(IEcsSystems systems) => _world = systems.GetWorld();

      public void Run(IEcsSystems systems) {
         foreach (int ev in _eventsBus.GetEventBodies(out EcsPool<HitEvent> hitEventPoll)) {
            HitEvent hitEvent = hitEventPoll.Get(ev);

            _gizmosService.Draw(() => hitEvent.DrawGizmos());
         }
      }
   }
}