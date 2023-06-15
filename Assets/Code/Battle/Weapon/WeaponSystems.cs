using Battle.Weapon.Aim;
using Battle.Weapon.Ammo._base;
using Battle.Weapon.Ammo.Reload;
using Battle.Weapon.Attack;
using Battle.Weapon.Projectiles;
using Engine.Ecs;
using Extensions.Ecs;

namespace Battle.Weapon {
  public class WeaponSystems : EcsSystemsPack {
    protected override void RegisterSystems() {
      Add<AimAtTargetSys>();
      Add<ShootSys>();
      Add<DelHereSys<BlockAttack>>();

      Add<ReduceAmmoSys>();

      Add<StartReloadingSys>();
      Add<ReloadingSys>();
      Add<DelHereSys<WantReload>>();
      Add<DelHereSys<BlockReload>>();

      Add<RestoreAttackSys>();
      Add<DelHereSys<IsAttacking>>();
    }
  }
}