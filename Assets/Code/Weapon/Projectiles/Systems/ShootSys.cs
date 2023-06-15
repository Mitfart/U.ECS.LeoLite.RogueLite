using System.Collections.Generic;
using System.Linq;
using Battle.Weapon.Attack;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;
using UnityRef;
using UnityRef.Extentions;
using VContainer;
using VContainer.Unity;

namespace Battle.Weapon.Projectiles {
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



    public void Run(IEcsSystems systems) {
      foreach (int e in _filter) {
        ref List<ConvertToEntity> projectiles  = ref _projectilesPool.Get(e).value;
        ref List<EcsTransform>    shootOrigins = ref _shootOriginsPool.Get(e).value;

        ConvertToEntity projectile   = projectiles[Random.Range(0, projectiles.Count - 1)];
        EcsTransform    displacement = _displacementPool.Has(e) ? _displacementPool.Get(e) : default;

        foreach (EcsTransform shootOrigin in shootOrigins.Select(origin => origin.WithParent(displacement))) {
          EcsTransform insDisp = shootOrigin;

          if (_spreadAnglePool.Has(e)) {
            Vector3 angles = insDisp.EulerAngles;
            angles.z            += _spreadAnglePool.Get(e).angle.GetRandom();
            insDisp.EulerAngles =  angles;
          }

          ConvertToEntity projectileInstance =
            _di.Instantiate(projectile, _insContainer)
               .GetComponent<ConvertToEntity>();

          Transform insT = projectileInstance.transform;
          insT.position = insDisp.position;
          insT.rotation = insDisp.rotation;
        }

        _isShootingPool.Add(e);
      }
    }

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
  }
}