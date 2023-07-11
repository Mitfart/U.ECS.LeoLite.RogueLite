using System;
using System.Collections.Generic;
using Extensions.Collections.Dictionary;
using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factories {
   public class EnemyFactory : Factory {
      private const string _CONTAINER_NAME = "Enemies";

      private readonly Dictionary<EnemyType, List<GameObject>> _enemies;


      public EnemyFactory(IAssets assets) : base(assets) {
         _enemies = new Dictionary<EnemyType, List<GameObject>>();
      }

      public override void Reset() {
         base.Reset();

         foreach (List<GameObject> enemies in _enemies.Values)
            enemies.Clear();

         _enemies.Clear();
      }



      public GameObject Spawn(EnemyType enemyType, Vector3 at) {
         try {
            GameObject enemyIns = Assets.Ins<GameObject>(
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



      private void Cache(EnemyType enemyType, GameObject ins)
         => _enemies
           .GetOrCreate(enemyType)
           .Add(ins);
   }
}