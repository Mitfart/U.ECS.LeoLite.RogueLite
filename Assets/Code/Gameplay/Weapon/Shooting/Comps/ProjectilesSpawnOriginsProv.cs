using System;
using System.Collections.Generic;
using Extensions.Ecs;
using Extensions.Unileo;
using Gameplay.UnityRef.Transform.Comp;
using Gameplay.UnityRef.Transform.Extensions;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.Weapon.Shooting.Comps {
   [DisallowMultipleComponent]
   public class ProjectilesSpawnOriginsProv : BaseEcsProvider<ProjectilesSpawnOrigins> {
      public List<Transform> origins;

      protected override void Add(EcsPool<ProjectilesSpawnOrigins> pool, int e, EcsWorld world) => pool.Set(e).value = origins.ConvertAll(ToEcs);

      private static EcsTransform ToEcs(Transform origin) {
         var ecsTransform = new EcsTransform { ParentE = origin.ParentEntity()?.AsPackedEntityWithWorld() };
         return ecsTransform.Sync(origin);
      }
   }

   [Serializable]
   public struct ProjectilesSpawnOrigins {
      public List<EcsTransform> value;
   }
}