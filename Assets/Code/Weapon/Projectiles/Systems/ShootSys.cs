using System.Collections.Generic;
using Extentions;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Weapon.Attack;

namespace Weapon.Projectiles {
  public class ShootSys : IEcsRunSystem, IEcsInitSystem {
    private readonly IObjectResolver _di; // *****************

    private EcsPool<EcsTransform> _displacementPool;
    private EcsFilter             _filter;
    private Transform             _insContainer; // *****************
    private EcsPool<IsAttacking>  _isShootingPool;
    private EcsPool<Projectiles>  _projectilesPool;

    private EcsPool<ProjectilesSpawnOrigins> _shootOriginsPool;
    private EcsPool<SpreadAngle>             _spreadAnglePool;
    private EcsWorld                         _world;

    public ShootSys(IObjectResolver di) {
      _di = di;
    } // *****************

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world
               .Filter<Weapon>()
               .Inc<ProjectilesSpawnOrigins>()
               .Inc<Projectiles>()
               .Inc<WantAttack>()
               .Exc<BlockAttack>()
               .End();

      _shootOriginsPool = _world.GetPool<ProjectilesSpawnOrigins>();
      _projectilesPool  = _world.GetPool<Projectiles>();

      _displacementPool = _world.GetPool<EcsTransform>();
      _isShootingPool   = _world.GetPool<IsAttacking>();
      _spreadAnglePool  = _world.GetPool<SpreadAngle>();

      _insContainer = new GameObject("Projectiles Container").transform;
    }



    public void Run(IEcsSystems systems) {
      foreach (int weaponE in _filter) {
        ref List<ConvertToEntity> projectiles  = ref _projectilesPool.Get(weaponE).value;
        ref List<EcsTransform>    shootOrigins = ref _shootOriginsPool.Get(weaponE).value;

        ConvertToEntity projectile = projectiles[Random.Range(0, projectiles.Count - 1)];

        foreach (EcsTransform shootOrigin in shootOrigins) {
          EcsTransform insTransform = shootOrigin;
          insTransform.ParentE = _world.PackEntityWithWorld(weaponE);

          if (_spreadAnglePool.Has(weaponE)) {
            Vector3 angles = insTransform.EulerAngles();
            angles.z += _spreadAnglePool.Get(weaponE).angle.GetRandom();
            insTransform.EulerAngles(angles);
          }

          ConvertToEntity projectileInstance =
            _di.Instantiate(projectile, _insContainer)
               .GetComponent<ConvertToEntity>();

          Transform insT = projectileInstance.transform;
          insT.position = insTransform.Position;
          insT.rotation = insTransform.Rotation;
        }

        _isShootingPool.Add(weaponE);
      }
    }
  }
}