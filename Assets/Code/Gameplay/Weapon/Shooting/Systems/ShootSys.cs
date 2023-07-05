using System.Collections.Generic;
using Extensions.Collections;
using Extensions.Ecs;
using Gameplay.UnityRef.Transform.Comp;
using Gameplay.UnityRef.Transform.Extensions;
using Gameplay.Weapon.Attack.Comps;
using Gameplay.Weapon.Shooting.Comps;
using Infrastructure.Factories.Projectiles;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using Structs.Ranged;
using UnityEngine;

namespace Gameplay.Weapon.Shooting.Systems {
   public class ShootSys : IEcsRunSystem, IEcsInitSystem {
      private readonly ProjectilesFactory _projectilesFactory;

      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Projectiles>             _projectilesPool;
      private EcsPool<ProjectilesSpawnOrigins> _shootOriginsPool;
      private EcsPool<IsAttacking>             _isAttackingPool;
      private EcsPool<SpreadAngle>             _spreadAnglePool;



      public ShootSys(ProjectilesFactory projectilesFactory) {
         _projectilesFactory = projectilesFactory;
      }

      public void Init(IEcsSystems systems) {
         _world = systems.GetWorld();
         _filter = _world.Filter<_base.Weapon>()
                         .Inc<Projectiles>()
                         .Inc<ProjectilesSpawnOrigins>()
                         .Inc<WantAttack>()
                         .Exc<BlockAttack>()
                         .End();

         _projectilesPool  = _world.GetPool<Projectiles>();
         _shootOriginsPool = _world.GetPool<ProjectilesSpawnOrigins>();

         _isAttackingPool = _world.GetPool<IsAttacking>();
         _spreadAnglePool = _world.GetPool<SpreadAngle>();
      }

      public void Run(IEcsSystems systems) {
         foreach (int weaponE in _filter) {
            foreach (EcsTransform shootOrigin in ShootOrigins(weaponE)) {
               EcsTransform insTransform = WithSpread(weaponE, shootOrigin.Refresh());

               _projectilesFactory.Spawn(
                  RandomProjectile(weaponE).name,
                  insTransform.Position,
                  insTransform.Rotation
               );
            }

            MarkAttacking(weaponE);
         }
      }



      private List<EcsTransform> ShootOrigins(int     weaponE) => _shootOriginsPool.Get(weaponE).value;
      private ConvertToEntity    RandomProjectile(int weaponE) => _projectilesPool.Get(weaponE).value.Random();
      private void               MarkAttacking(int    weaponE) => _isAttackingPool.Add(weaponE);
      
      private EcsTransform WithSpread(int weaponE, EcsTransform insTransform) {
         if (!HasSpread(weaponE, out Ranged angle))
            return insTransform;

         Vector3 angles = insTransform.EulerAngles();
         angles.z += angle.GetRandom();
         insTransform.SetEulerAngles(angles);

         return insTransform;
      }

      private bool HasSpread(int weaponE, out Ranged angle) {
         if (_spreadAnglePool.TryGet(weaponE, out SpreadAngle spread)) {
            angle = spread.angle;
            return true;
         }
         
         angle = default;
         return false;
      }
   }
}