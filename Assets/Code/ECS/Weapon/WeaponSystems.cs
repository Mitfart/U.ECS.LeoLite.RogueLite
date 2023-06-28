using ECS.Weapon.Aim;
using ECS.Weapon.Aim.Debug;
using ECS.Weapon.Ammo;
using ECS.Weapon.Ammo.Reload;
using ECS.Weapon.Attack;
using ECS.Weapon.Shooting;
using Engine.Ecs;
using Extensions.Ecs;

namespace ECS.Weapon {
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