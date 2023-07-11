using Extensions.Ecs;
using Gameplay.Weapon.Ammo.Comps;
using Gameplay.Weapon.Attack.Comps;
using Infrastructure.Services.Time;
using Leopotam.EcsLite;

namespace Gameplay.Weapon.Ammo.Systems {
   public class ReloadingSys : IEcsRunSystem, IEcsInitSystem {
      private ITimeService _timeService;
      private EcsWorld     _world;
      private EcsFilter    _filter;

      private EcsPool<Reload.Reload> _reloadDurationPool;
      private EcsPool<Magazine>      _magazinePool;
      private EcsPool<BlockAttack>   _blockAttackPool;



      public ReloadingSys(ITimeService timeService) {
         _timeService = timeService;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<Reload.Reload>()
                         .Inc<Magazine>()
                         .End();

         _reloadDurationPool = _world.GetPool<Reload.Reload>();
         _magazinePool       = _world.GetPool<Magazine>();
         _blockAttackPool    = _world.GetPool<BlockAttack>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            ref Reload.Reload reload   = ref _reloadDurationPool.Get(e);
            ref Magazine      magazine = ref _magazinePool.Get(e);

            if (!_timeService.PassTime(reload.startTime, reload.duration)) {
               _blockAttackPool.TryAdd(e);
               continue;
            }

            magazine.amount = magazine.size;
            _blockAttackPool.TryDel(e);
         }
      }
   }
}