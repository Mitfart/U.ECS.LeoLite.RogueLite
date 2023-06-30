using ECS.View;

namespace View {
   public class BulletView : EcsView {
      public override void OnDestroyEntity() => Destroy(gameObject);
   }
}