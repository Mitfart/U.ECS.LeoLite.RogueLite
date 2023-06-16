using Engine.Ecs;
using Extensions.Ecs;
using Weapon.Aim;
using Weapon.Aim.Debug;
using Weapon.Ammo._base;
using Weapon.Ammo.Reload;
using Weapon.Attack;
using Weapon.Projectiles;

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

#if UNITY_EDITOR
      Add<DrawAimSys>();
#endif

      Add<RestoreAttackSys>();
      Add<DelHereSys<IsAttacking>>();
    }
  }
}