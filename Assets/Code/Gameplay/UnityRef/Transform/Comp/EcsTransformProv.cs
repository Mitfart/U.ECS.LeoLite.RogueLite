using Extensions.Ecs;
using Gameplay.UnityRef.Transform.Extensions;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Gameplay.UnityRef.Transform.Comp {
   public class EcsTransformProv : BaseEcsProvider<EcsTransform> {
      protected override void Add(EcsPool<EcsTransform> pool, int e, EcsWorld world) {
         pool.Set(e).Sync(transform);
         world.GetPool<URefTransform>().Set(e).Component = transform;
      }
   }
}