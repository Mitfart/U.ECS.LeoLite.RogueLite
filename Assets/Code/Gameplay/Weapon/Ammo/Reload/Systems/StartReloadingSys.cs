using Gameplay.Weapon.Ammo.Reload;
using Infrastructure.Services.Time;
using Leopotam.EcsLite;

namespace Gameplay.Weapon.Ammo.Systems {
   public class StartReloadingSys : IEcsRunSystem, IEcsInitSystem {
      private readonly ITimeService _timeService;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Reload.Reload> _reloadPool;



      public StartReloadingSys(ITimeService timeService) {
         _timeService = timeService;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<Reload.Reload>()
                         .Inc<WantReload>()
                         .Exc<BlockReload>()
                         .End();

         _reloadPool = _world.GetPool<Reload.Reload>();
      }

      public void Run(IEcsSystems systems) {
         float time = _timeService.Time;

         foreach (int e in _filter)
            _reloadPool.Get(e).startTime = time;
      }
   }
}