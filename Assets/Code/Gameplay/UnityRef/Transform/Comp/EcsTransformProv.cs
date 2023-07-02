using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityRef.Extensions;

namespace UnityRef {
   public class EcsTransformProv : BaseEcsProvider {
      public override void Convert(int e, EcsWorld world) {
         world.GetPool<URefTransform>().Set(e).Component = transform;
         world.GetPool<EcsTransform>().Set(e).Sync(transform);

         Destroy(this);
      }
   }
}