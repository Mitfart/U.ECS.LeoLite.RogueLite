using System;
using System.Collections.Generic;
using ECS.UnityRef;
using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace ECS.Weapon.Shooting {
   [DisallowMultipleComponent]
   public class ProjectilesSpawnOriginsProv : BaseEcsProvider {
      public List<Transform> origins;

      public override void Convert(int e, EcsWorld world) {
         world.GetPool<ProjectilesSpawnOrigins>().Set(e).value = origins.ConvertAll(ToEcs);
         Destroy(this);
      }

      private static EcsTransform ToEcs(Transform origin) {
         return new(origin);
      }
   }

   [Serializable]
   public struct ProjectilesSpawnOrigins {
      public List<EcsTransform> value;
   }
}