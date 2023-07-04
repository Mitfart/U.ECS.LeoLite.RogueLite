using System;
using System.Collections.Generic;
using Extensions.Collections.Dictionary;
using Infrastructure.AssetsManagement;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Infrastructure.Factories {
   public class EnemyFactory : Factory {
      private readonly Dictionary<EnemyType, List<ConvertToEntity>> _enemies;



      public EnemyFactory(IAssets assets) : base(assets) {
         _enemies = new Dictionary<EnemyType, List<ConvertToEntity>>();
      }

      public ConvertToEntity Spawn(EnemyType enemyType, Vector3 at) {
         try {
            ConvertToEntity enemyIns = Assets.Ins<ConvertToEntity>(PathOf(enemyType), at);
            Cache(enemyType, enemyIns);
            return enemyIns;
         } catch (Exception e) {
            UnityEngine.Debug.LogWarning($"Can't Spawn enemy! <{enemyType}>");
            return null;
         }
      }


      private void Cache(EnemyType enemyType, ConvertToEntity enemyIns) {
         _enemies
           .GetOrCreate(enemyType)
           .Add(enemyIns);
      }

      private static string PathOf(EnemyType enemyType) => $"Enemies/{enemyType.ToString()}";
   }
}