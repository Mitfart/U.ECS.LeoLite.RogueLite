using Extensions.Ecs;
using Leopotam.EcsLite;
using UnityEngine;

namespace Weapon.Attack {
   public class RestoreAttackSys : IEcsRunSystem, IEcsInitSystem {
      private EcsPool<BlockAttack> _cantAttackPool;
      private EcsFilter            _filter;
      private EcsPool<IsAttacking> _isAttackingPool;

      private EcsPool<RestoreAttackTimer> _restoreAttackPool;
      private EcsWorld                    _world;

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<RestoreAttackTimer>().Inc<WeaponTag>().Exc<BlockAttack>().End();

         _restoreAttackPool = _world.GetPool<RestoreAttackTimer>();
         _cantAttackPool    = _world.GetPool<BlockAttack>();
         _isAttackingPool   = _world.GetPool<IsAttacking>();
      }

      public void Run(IEcsSystems systems) {
         float time = Time.time;

         foreach (int e in _filter) {
            ref RestoreAttackTimer restoreShot = ref _restoreAttackPool.Get(e);

            if (time < restoreShot.startTime + restoreShot.duration) {
               _cantAttackPool.TryAdd(e);
            } else if (_isAttackingPool.Has(e)) {
               restoreShot.startTime = time;
               if (time < restoreShot.startTime + restoreShot.duration) _cantAttackPool.TryAdd(e);
            } else {
               _cantAttackPool.TryDel(e);
            }
         }
      }
   }
}