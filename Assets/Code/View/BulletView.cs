using Features.View;

namespace Views {
  public class BulletView : EcsView {
    public override void OnDestroyEntity() {
      Destroy(gameObject);
    }
  }
}