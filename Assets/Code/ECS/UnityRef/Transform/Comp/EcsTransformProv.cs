using System;
using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Unity.VisualScripting;

namespace ECS.UnityRef {
   public class EcsTransformProv : BaseEcsProvider {
      public override void Convert(int e, EcsWorld world) {
         if (transform.IsUnityNull()) throw new NullReferenceException("Value cant be Null!");

         world.GetPool<URefTransform>().Set(e).Component = transform;
         world.GetPool<EcsTransform>().Set(e)            = new EcsTransform(transform);

         Destroy(this);
      }
   }
}