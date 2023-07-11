using System.Collections.Generic;
using Extensions.Collections.Dictionary;
using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factories.Projectiles {
   public class ProjectilesFactory : Factory {
      private const string _CONTAINER_NAME = "Projectiles";

      private readonly Dictionary<string, List<GameObject>> _projectiles;



      public ProjectilesFactory(IAssets assets) : base(assets) {
         _projectiles = new Dictionary<string, List<GameObject>>();
      }

      public override void Reset() {
         base.Reset();

         foreach (List<GameObject> projectiles in _projectiles.Values) {
            projectiles.Clear();
         }

         _projectiles.Clear();
      }



      public GameObject Spawn(string id, Vector3 at, Quaternion rot) {
         GameObject projectileIns = Assets.Ins<GameObject>(
            AssetPath.ProjectilePath(id),
            at,
            rot,
            Container(_CONTAINER_NAME, id)
         );

         Cache(id, projectileIns);
         return projectileIns;
      }

      private void Cache(string id, GameObject ins)
         => _projectiles
           .GetOrCreate(id)
           .Add(ins);
   }
}