using Extensions.Ecs;
using Leopotam.EcsLite;
using UnityEngine;
using Weapon.Ammo.Reload;
using Weapon.Attack;

namespace Weapon.Ammo {
   public class ReloadingSys : IEcsRunSystem, IEcsInitSystem {
      private EcsPool<Ammo>        _ammoPool;
      private EcsPool<BlockAttack> _cantShootPool;
      private EcsFilter            _filter;
      private EcsPool<IsReloading> _isReloadingPool;

      private EcsPool<Magazine> _magazinePool;

      private EcsPool<ReloadDuration> _reloadDurationPool;
      private EcsWorld                _world;

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<ReloadDuration>().Inc<Magazine>().Inc<IsReloading>().End();

         _reloadDurationPool = _world.GetPool<ReloadDuration>();
         _isReloadingPool    = _world.GetPool<IsReloading>();
         _cantShootPool      = _world.GetPool<BlockAttack>();

         _magazinePool = _world.GetPool<Magazine>();
         _ammoPool     = _world.GetPool<Ammo>();
      }

      public void Run(IEcsSystems systems) {
         float time = Time.time;

         foreach (int e in _filter) {
            ref ReloadDuration reloadDuration = ref _reloadDurationPool.Get(e);
            ref Magazine       magazine       = ref _magazinePool.Get(e);

            if (time < reloadDuration.startTime + reloadDuration.duration) {
               _cantShootPool.TryAdd(e);
               continue;
            }

            magazine.amount = _ammoPool.TryGet(e, out Ammo ammo) ? Mathf.Min(ammo.amount, magazine.size) : magazine.size;
            _isReloadingPool.Del(e);
            _cantShootPool.TryDel(e);
         }
      }
   }
}