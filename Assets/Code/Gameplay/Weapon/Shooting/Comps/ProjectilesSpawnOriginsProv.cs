using System;
using System.Collections.Generic;
using Extensions.Ecs;
using Extensions.Unileo;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;
using UnityRef;
using UnityRef.Extensions;

namespace Weapon.Shooting {
   [DisallowMultipleComponent]
   public class ProjectilesSpawnOriginsProv : BaseEcsProvider {
      public List<Transform> origins;

      public override void Convert(int e, EcsWorld world) {
         world.GetPool<ProjectilesSpawnOrigins>().Set(e).value = origins.ConvertAll(ToEcs);
         Destroy(this);
      }

      private static EcsTransform ToEcs(Transform origin) {
         var ecsTransform = new EcsTransform { ParentE = origin.ParentEntity() };
         return ecsTransform.Sync(origin);
      }
   }

   [Serializable]
   public struct ProjectilesSpawnOrigins {
      public List<EcsTransform> value;
   }
}