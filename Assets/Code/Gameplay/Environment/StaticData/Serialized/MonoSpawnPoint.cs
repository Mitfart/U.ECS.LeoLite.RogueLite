using Gameplay.Environment.StaticData;
using UnityEngine;

namespace Gameplay.Environment {
   public class MonoSpawnPoint : MonoBehaviour, ISerializationCallbackReceiver {
      public SpawnPoint SpawnPoint;


#if UNITY_EDITOR
      public void OnBeforeSerialize() {
         SpawnPoint.Position = transform.position;
         UnityEditor.EditorUtility.SetDirty(this);
      }

      public void OnAfterDeserialize() { }
#endif
   }
}