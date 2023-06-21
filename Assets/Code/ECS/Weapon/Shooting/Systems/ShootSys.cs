using System.Collections.Generic;
using Extensions.EcsTransform;
using Features.Weapon.Attack;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;
using UnityRef;
using VContainer;
using VContainer.Unity;

namespace Features.Weapon.Projectiles {
  public class ShootSys : IEcsRunSystem, IEcsInitSystem {
    private const string PROJECTILES_CONTAINER_NAME = "Projectiles Container";

    private readonly IObjectResolver _di;

    private EcsWorld  _world;
    private EcsFilter _filter;
    private Transform _insContainer;

    private EcsPool<Projectiles>             _projectilesPool;
    private EcsPool<ProjectilesSpawnOrigins> _shootOriginsPool;
    private EcsPool<IsAttacking>             _isAttackingPool;
    private EcsPool<SpreadAngle>             _spreadAnglePool;



    public ShootSys(IObjectResolver di) {
      _di = di;
    }

    public void Run(IEcsSystems systems) {
      foreach (int weaponE in _filter) {
        foreach (EcsTransform shootOrigin in ShootOrigins(weaponE)) {
          EcsTransform insTransform = shootOrigin.Refresh();

          SpawnRandomProjectile(
            WithSpread(weaponE, ref insTransform),
            weaponE
          );
        }

        MarkAttacking(weaponE);
      }
    }

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world
               .Filter<WeaponTag>()
               .Inc<Projectiles>()
               .Inc<ProjectilesSpawnOrigins>()
               .Inc<WantAttack>()
               .Exc<BlockAttack>()
               .End();

      _projectilesPool  = _world.GetPool<Projectiles>();
      _shootOriginsPool = _world.GetPool<ProjectilesSpawnOrigins>();

      _isAttackingPool = _world.GetPool<IsAttacking>();
      _spreadAnglePool = _world.GetPool<SpreadAngle>();

      _insContainer = InsContainer();
    }



    private List<EcsTransform> ShootOrigins(int  weaponE) => _shootOriginsPool.Get(weaponE).value;
    private void               MarkAttacking(int weaponE) => _isAttackingPool.Add(weaponE);

    private ref EcsTransform WithSpread(int weaponE, ref EcsTransform insTransform) {
      if (!_spreadAnglePool.Has(weaponE))
        return ref insTransform;

      Vector3 angles = insTransform.EulerAngles();
      angles.z += _spreadAnglePool.Get(weaponE).angle.GetRandom();
      insTransform.SetEulerAngles(angles);

      return ref insTransform;
    }

    private void SpawnRandomProjectile(EcsTransform insTransform, int weaponE) {
      _di.Instantiate(GetRandomProjectile(weaponE), _insContainer)
         .transform
         .Sync(insTransform);
    }

    private ConvertToEntity GetRandomProjectile(int weaponE) {
      ref List<ConvertToEntity> projectiles = ref _projectilesPool.Get(weaponE).value;
      return projectiles[Random.Range(0, projectiles.Count - 1)];
    }

    private static Transform InsContainer() => new GameObject(PROJECTILES_CONTAINER_NAME).transform;
  }
}