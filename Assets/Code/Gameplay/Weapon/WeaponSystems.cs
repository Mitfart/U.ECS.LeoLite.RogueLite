using Engine.Ecs;
using Extensions.Ecs;
using Weapon.Aim;
using Weapon.Aim.Debug;
using Weapon.Ammo;
using Weapon.Ammo.Reload;
using Weapon.Attack;
using Weapon.Shooting;

namespace Weapon {
   public class WeaponSystems : EcsSystemsPack {
      protected override void RegisterSystems() {
         Add<AimSys>();
         Add<ShootSys>();
         Add<DelHereSys<BlockAttack>>();

         Add<ReduceAmmoSys>();

         Add<StartReloadingSys>();
         Add<ReloadingSys>();
         Add<DelHereSys<WantReload>>();
         Add<DelHereSys<BlockReload>>();

         Add<RestoreAttackSys>();
         Add<DelHereSys<IsAttacking>>();

#if UNITY_EDITOR
         Add<DrawAimSys>();
#endif
      }
   }
}