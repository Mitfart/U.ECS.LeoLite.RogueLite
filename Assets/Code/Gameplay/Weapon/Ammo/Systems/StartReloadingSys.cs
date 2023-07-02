using Extensions.Ecs;
using Gameplay.Weapon.Ammo.Extensions;
using Gameplay.Weapon.Ammo.Reload;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Weapon.Ammo.Systems {
   public class StartReloadingSys : IEcsRunSystem, IEcsInitSystem {
      private EcsPool<Comps.Ammo>  _ammoPool;
      private EcsFilter            _filter;
      private EcsPool<IsReloading> _isReloadingPool;

      private EcsPool<ReloadDuration> _reloadDurationPool;
      private EcsWorld                _world;

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<ReloadDuration>().Inc<WantReload>().Exc<BlockReload>().Exc<IsReloading>().End();

         _reloadDurationPool = _world.GetPool<ReloadDuration>();
         _isReloadingPool    = _world.GetPool<IsReloading>();
         _ammoPool           = _world.GetPool<Comps.Ammo>();
      }

      public void Run(IEcsSystems systems) {
         float time = Time.time;

         foreach (int e in _filter) {
            ref ReloadDuration reloadDuration = ref _reloadDurationPool.Get(e);

            if (_ammoPool.TryGet(e, out Comps.Ammo ammo) && ammo.IsEmpty())
               return;

            reloadDuration.startTime = time;
            _isReloadingPool.Add(e);
         }
      }
   }
}