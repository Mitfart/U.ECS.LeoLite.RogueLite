using Extensions.Ecs;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.UnityRef.Abstract {
   public class EcsUnityURefProv<TMono, TComp> : BaseEcsProvider<TComp>, ISerializationCallbackReceiver where TMono : Component where TComp : struct, IEcsURef<TMono> {
      public TMono component;



      public virtual void OnBeforeSerialize()  => GetComponentRef();
      public virtual void OnAfterDeserialize() { }


      protected override void Add(EcsPool<TComp> pool, int e, EcsWorld world) => pool.Set(e).Component = GetComponentRef();

      private TMono GetComponentRef() {
         if (component.IsUnityNull() && TryGetComponent(out TMono comp))
            component = comp;

         return component;
      }
   }
}