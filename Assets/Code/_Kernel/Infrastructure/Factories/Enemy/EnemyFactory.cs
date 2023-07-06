using System;
using System.Collections.Generic;
using Extensions.Collections.Dictionary;
using Infrastructure.AssetsManagement;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Infrastructure.Factories {
   public class EnemyFactory : Factory {
      private const string _CONTAINER_NAME = "Enemies";

      private readonly Dictionary<EnemyType, List<ConvertToEntity>> _enemies;


      public EnemyFactory(IAssets assets) : base(assets) {
         _enemies = new Dictionary<EnemyType, List<ConvertToEntity>>();
      }

      public override void Reset() {
         base.Reset();

         foreach (List<ConvertToEntity> enemies in _enemies.Values) {
            enemies.Clear();
         }

         _enemies.Clear();
      }



      public ConvertToEntity Spawn(EnemyType enemyType, Vector3 at) {
         try {
            ConvertToEntity enemyIns = Assets.Ins<ConvertToEntity>(
               AssetPath.EnemyPath(enemyType),
               at,
               Quaternion.identity,
               Container(_CONTAINER_NAME, enemyType.ToString())
            );

            Cache(enemyType, enemyIns);
            return enemyIns;
         } catch (Exception exc) {
            Debug.LogWarning($"Can't Spawn enemy! <{enemyType}> \n {exc}");
            return null;
         }
      }



      private void Cache(EnemyType enemyType, ConvertToEntity ins)
         => _enemies
           .GetOrCreate(enemyType)
           .Add(ins);
   }
}