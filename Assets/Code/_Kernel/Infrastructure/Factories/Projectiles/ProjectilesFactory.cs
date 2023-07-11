using System.Collections.Generic;
using Extensions.Collections.Dictionary;
using Infrastructure.AssetsManagement;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Infrastructure.Factories.Projectiles {
   public class ProjectilesFactory : Factory {
      private const string _CONTAINER_NAME = "Projectiles";

      private readonly Dictionary<string, List<EntityConverter>> _projectiles;

      private readonly EcsWorld _world;



      public ProjectilesFactory(IAssets assets, EcsWorld world) : base(assets) {
         _world       = world;
         _projectiles = new Dictionary<string, List<EntityConverter>>();
      }

      public override void Reset() {
         base.Reset();

         foreach (List<EntityConverter> projectiles in _projectiles.Values) {
            projectiles.Clear();
         }

         _projectiles.Clear();
      }



      public EntityConverter Spawn(string id, Vector3 at, Quaternion rot) {
         EntityConverter projectileIns = Assets.Ins<EntityConverter>(
            AssetPath.ProjectilePath(id),
            at,
            rot,
            Container(_CONTAINER_NAME, id)
         );

         projectileIns.Convert(_world, _world.NewEntity());

         Cache(id, projectileIns);
         return projectileIns;
      }

      private void Cache(string id, EntityConverter ins)
         => _projectiles
           .GetOrCreate(id)
           .Add(ins);
   }
}