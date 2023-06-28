using UnityEngine;

namespace ECS.View {
   public class EcsView : MonoBehaviour, IEvsView {
      public virtual void Refresh() { }

      public virtual void OnDestroyEntity() { }
   }
}