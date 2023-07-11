using System;
using System.Collections.Generic;
using Extensions.Collections.Dictionary;
using Infrastructure.AssetsManagement;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Infrastructure.Factories {
   public class EnemyFactory : Factory {
      private const string _CONTAINER_NAME = "Enemies";

      private readonly Dictionary<EnemyType, List<EntityConverter>> _enemies;

      private readonly EcsWorld _world;



      public EnemyFactory(IAssets assets, EcsWorld world) : base(assets) {
         _world   = world;
         _enemies = new Dictionary<EnemyType, List<EntityConverter>>();
      }

      public override void Reset() {
         base.Reset();

         foreach (List<EntityConverter> enemies in _enemies.Values)
            enemies.Clear();

         _enemies.Clear();
      }



      public void Spawn(EnemyType enemyType, Vector3 at) {
         try {
            EntityConverter enemyIns = Assets.Ins<EntityConverter>(
               AssetPath.EnemyPath(enemyType),
               at,
               Quaternion.identity,
               Container(_CONTAINER_NAME, enemyType.ToString())
            );

            enemyIns.Convert(_world, _world.NewEntity());

            Cache(enemyType, enemyIns);
         } catch (Exception exc) {
            Debug.LogWarning($"Can't Spawn enemy! <{enemyType}> \n {exc}");
         }
      }



      private void Cache(EnemyType enemyType, EntityConverter ins)
         => _enemies
           .GetOrCreate(enemyType)
           .Add(ins);
   }
}