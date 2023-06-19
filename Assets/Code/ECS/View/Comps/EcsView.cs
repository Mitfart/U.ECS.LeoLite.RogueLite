using UnityEngine;

namespace Features.View {
  public abstract class EcsView : MonoBehaviour, IEvsView {
    public abstract void Refresh();

    public abstract void OnDestroy();
  }
}