using UnityEngine;

namespace UnityRef {
   public interface IEcsURef<T> where T : Component {
      public T Component { get; set; }
   }
}