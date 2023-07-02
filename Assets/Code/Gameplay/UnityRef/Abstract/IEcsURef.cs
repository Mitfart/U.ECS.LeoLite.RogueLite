using UnityEngine;

namespace Gameplay.UnityRef.Abstract {
   public interface IEcsURef<T> where T : Component {
      public T Component { get; set; }
   }
}