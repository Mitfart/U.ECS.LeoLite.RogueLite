using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Unity.VisualScripting;
using UnityEngine;

namespace ECS.UnityRef {
   public abstract class EcsUnityURefProv<TMono, TComp> : BaseEcsProvider, ISerializationCallbackReceiver where TMono : Component where TComp : struct, IEcsURef<TMono> {
      public TMono component;


      public virtual void OnBeforeSerialize() => GetComponentRef();

      public virtual void OnAfterDeserialize() => GetComponentRef();


      public override void Convert(int e, EcsWorld world) {
         GetComponentRef();

         world.GetPool<TComp>().Set(e).Component = component;

         Destroy(this);
      }


      private void GetComponentRef() {
         if (component.IsUnityNull() && TryGetComponent(out TMono comp)) component = comp;
      }
   }
}