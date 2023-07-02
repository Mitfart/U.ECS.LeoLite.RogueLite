using Leopotam.EcsLite;
using UnityEngine;

namespace View {
   // not abstract because of Unity Serialization
   public class EcsView : MonoBehaviour, IEvsView {
      public virtual void Refresh(EcsWorld world, int entity) { }

      public virtual void OnDestroyEntity(EcsWorld world, int entity) {
         Destroy(gameObject);
      }
   }
}