using UnityEngine;

namespace ECS.UnityRef {
   public interface IEcsURef<T> where T : Component {
      public T Component { get; set; }
   }
}