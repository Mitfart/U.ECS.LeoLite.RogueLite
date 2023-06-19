using Features.View;

namespace Views {
  public class BulletView : EcsView {
    public override void Refresh() {
      
    }

    public override void OnDestroy() {
      Destroy(gameObject);
    }
  }
}