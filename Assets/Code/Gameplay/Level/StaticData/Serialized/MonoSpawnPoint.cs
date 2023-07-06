using UnityEditor;
using UnityEngine;

namespace Gameplay.Level.StaticData.Serialized {
   public class MonoSpawnPoint : MonoBehaviour, ISerializationCallbackReceiver {
#if UNITY_EDITOR
      public SpawnPoint spawnPoint;


      public void OnBeforeSerialize() {
         spawnPoint.position = transform.position;
         EditorUtility.SetDirty(this);
      }

      public void OnAfterDeserialize() { }
#endif
   }
}