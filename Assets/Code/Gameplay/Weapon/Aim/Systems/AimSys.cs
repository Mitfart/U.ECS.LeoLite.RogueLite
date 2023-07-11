using Gameplay.UnityRef.Transform.Comp;
using Gameplay.UnityRef.Transform.Extensions;
using Gameplay.Weapon._base;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Weapon.Aim {
   public class AimSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<WeaponOwner>  _weaponOwnerPool;
      private EcsPool<AimPosition>  _aimPositionPool;
      private EcsPool<EcsTransform> _ecsTransformPool;



      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<WeaponOwner>().Inc<AimPosition>().End();

         _weaponOwnerPool  = _world.GetPool<WeaponOwner>();
         _aimPositionPool  = _world.GetPool<AimPosition>();
         _ecsTransformPool = _world.GetPool<EcsTransform>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            if (HasWeapon(e, out int weaponE))
               Transform(weaponE)
                 .LookAt2D(AimPosition(e));
         }
      }



      private bool HasWeapon(int ownerE, out int weaponE) {
         weaponE = -1;
         return _weaponOwnerPool.Get(ownerE).weapon?.Unpack(out _, out weaponE) == true;
      }

      private ref Vector3      AimPosition(int e)       => ref _aimPositionPool.Get(e).value;
      private ref EcsTransform Transform(int   weaponE) => ref _ecsTransformPool.Get(weaponE);
   }
}