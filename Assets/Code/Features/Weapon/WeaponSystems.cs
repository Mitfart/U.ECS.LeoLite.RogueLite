using Engine.Ecs;
using Extensions.Ecs;
using Features.Weapon.Aim;
using Features.Weapon.Aim.Debug;
using Features.Weapon.Ammo._base;
using Features.Weapon.Ammo.Reload;
using Features.Weapon.Attack;
using Features.Weapon.Projectiles;

namespace Features.Weapon {
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