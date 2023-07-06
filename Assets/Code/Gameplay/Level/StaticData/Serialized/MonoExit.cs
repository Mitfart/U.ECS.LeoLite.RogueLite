using UnityEngine;

namespace Gameplay.Level.StaticData.Serialized {
   public class MonoExit : MonoBehaviour {
#if UNITY_EDITOR
      public Vector3 Position => transform.position;
#endif
   }
}