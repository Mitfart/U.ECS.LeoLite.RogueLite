using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.View.Comps {
   public abstract class EcsView : MonoBehaviour, IEcsView {
      public abstract void Refresh(EcsWorld world, int entity);

      public virtual void OnDestroyEntity(EcsWorld world, int entity) { }
   }
}