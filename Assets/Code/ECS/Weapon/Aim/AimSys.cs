using System;
using ECS.UnityRef;
using ECS.UnityRef.Extensions;
using Leopotam.EcsLite;

namespace ECS.Weapon.Aim {
   public class AimSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<WeaponOwner>  _activeWeaponsPool;
      private EcsPool<AimPosition>  _aimPositionPool;
      private EcsPool<EcsTransform> _ecsTransformPool;

      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<WeaponOwner>().Inc<AimPosition>().End();

         _activeWeaponsPool = _world.GetPool<WeaponOwner>();
         _aimPositionPool   = _world.GetPool<AimPosition>();
         _ecsTransformPool  = _world.GetPool<EcsTransform>();
      }



      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            ref WeaponOwner weaponOwner = ref _activeWeaponsPool.Get(e);
            ref AimPosition aimPosition = ref _aimPositionPool.Get(e);

            GetTransform(weaponOwner.Weapon).LookAt2D(aimPosition.value);
         }
      }



      private ref EcsTransform GetTransform(EcsPackedEntity weapon) {
         if (!GetEntity(weapon, out int weaponE)) throw new Exception(message: "Weapon is not set!");

         return ref _ecsTransformPool.Get(weaponE);
      }

      private bool GetEntity(EcsPackedEntity activeWeapon, out int weaponE) => activeWeapon.Unpack(_world, out weaponE);
   }
}