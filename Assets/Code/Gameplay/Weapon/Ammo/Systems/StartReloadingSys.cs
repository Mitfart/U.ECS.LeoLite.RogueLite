using Extensions.Ecs;
using Leopotam.EcsLite;
using UnityEngine;
using Weapon.Ammo.Extensions;
using Weapon.Ammo.Reload;

namespace Weapon.Ammo {
   public class StartReloadingSys : IEcsRunSystem, IEcsInitSystem {
      private EcsPool<Ammo>        _ammoPool;
      private EcsFilter            _filter;
      private EcsPool<IsReloading> _isReloadingPool;

      private EcsPool<ReloadDuration> _reloadDurationPool;
      private EcsWorld                _world;

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<ReloadDuration>().Inc<WantReload>().Exc<BlockReload>().Exc<IsReloading>().End();

         _reloadDurationPool = _world.GetPool<ReloadDuration>();
         _isReloadingPool    = _world.GetPool<IsReloading>();
         _ammoPool           = _world.GetPool<Ammo>();
      }

      public void Run(IEcsSystems systems) {
         float time = Time.time;

         foreach (int e in _filter) {
            ref ReloadDuration reloadDuration = ref _reloadDurationPool.Get(e);

            if (_ammoPool.TryGet(e, out Ammo ammo) && ammo.IsEmpty()) return;

            reloadDuration.startTime = time;
            _isReloadingPool.Add(e);
         }
      }
   }
}