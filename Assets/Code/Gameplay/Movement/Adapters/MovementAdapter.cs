using Gameplay.Movement.Comps;
using Gameplay.UnityRef.Transform.Comp;
using Gameplay.UnityRef.Transform.Extensions;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Gameplay.Movement.Adapters {
   public class MovementAdapter : BaseEcsAdapter {
      public float speed;

      public override void Convert() {
         Set<RefTransform>().Component = transform;
         Set<EcsTransform>().Sync(transform);
         Set<MoveTo>().position = transform.position;
         Set<Speed>().value     = speed;
      }
   }
}