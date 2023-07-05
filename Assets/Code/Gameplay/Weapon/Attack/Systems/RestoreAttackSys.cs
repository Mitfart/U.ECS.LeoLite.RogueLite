using Extensions.Ecs;
using Gameplay.Weapon.Attack.Comps;
using Infrastructure.Services.Time;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Weapon.Attack.Systems {
   public class RestoreAttackSys : IEcsRunSystem, IEcsInitSystem {
      private readonly ITimeService _timeService;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<BlockAttack>        _cantAttackPool;
      private EcsPool<IsAttacking>        _isAttackingPool;
      private EcsPool<RestoreAttackTimer> _restoreAttackPool;



      public RestoreAttackSys(ITimeService timeService) {
         _timeService = timeService;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<RestoreAttackTimer>()
                         .Inc<_base.Weapon>()
                         .Exc<BlockAttack>()
                         .End();

         _restoreAttackPool = _world.GetPool<RestoreAttackTimer>();
         _cantAttackPool    = _world.GetPool<BlockAttack>();
         _isAttackingPool   = _world.GetPool<IsAttacking>();
      }

      public void Run(IEcsSystems systems) {
         float time = _timeService.Time;

         foreach (int e in _filter) {
            ref RestoreAttackTimer restoreShot = ref _restoreAttackPool.Get(e);

            if (time < restoreShot.startTime + restoreShot.duration) {
               _cantAttackPool.TryAdd(e);
            } else if (_isAttackingPool.Has(e)) {
               restoreShot.startTime = time;
               if (time < restoreShot.startTime + restoreShot.duration)
                  _cantAttackPool.TryAdd(e);
            } else {
               _cantAttackPool.TryDel(e);
            }
         }
      }
   }
}