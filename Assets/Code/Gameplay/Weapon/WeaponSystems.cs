using Extensions.Ecs;
using Gameplay.Weapon.Aim;
using Gameplay.Weapon.Aim.Debug;
using Gameplay.Weapon.Ammo.Reload;
using Gameplay.Weapon.Ammo.Systems;
using Gameplay.Weapon.Attack.Comps;
using Gameplay.Weapon.Attack.Systems;
using Gameplay.Weapon.Shooting.Systems;

namespace Gameplay.Weapon {
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