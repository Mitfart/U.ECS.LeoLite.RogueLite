using System.Collections.Generic;
using Extensions.Collections.Dictionary;
using Infrastructure.AssetsManagement;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Infrastructure.Factories.Projectiles {
   public class ProjectilesFactory : Factory {
      private const string _CONTAINER_NAME = "Projectiles";

      private readonly Dictionary<string, List<ConvertToEntity>> _projectiles;



      public ProjectilesFactory(IAssets assets) : base(assets) {
         _projectiles = new Dictionary<string, List<ConvertToEntity>>();
      }

      public override void Reset() {
         base.Reset();

         foreach (List<ConvertToEntity> projectiles in _projectiles.Values) {
            projectiles.Clear();
         }

         _projectiles.Clear();
      }



      public ConvertToEntity Spawn(string id, Vector3 at, Quaternion rot) {
         ConvertToEntity projectileIns = Assets.Ins<ConvertToEntity>(
            AssetPath.ProjectilePath(id),
            at,
            rot,
            Container(_CONTAINER_NAME, id)
         );

         Cache(id, projectileIns);
         return projectileIns;
      }

      private void Cache(string id, ConvertToEntity ins)
         => _projectiles
           .GetOrCreate(id)
           .Add(ins);
   }
}