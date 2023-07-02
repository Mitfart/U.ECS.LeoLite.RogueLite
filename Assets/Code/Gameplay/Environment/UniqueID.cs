using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Gameplay.Level {
   [DisallowMultipleComponent]
   public class UniqueID : MonoBehaviour, ISerializationCallbackReceiver {
      [field: SerializeField] public string ID { get; private set; }


#if UNITY_EDITOR
      public void OnBeforeSerialize() {
         if (Application.isPlaying)
            return;

         while (!Prefab() && !ValidID()) {
            ID = GenerateID();
         }
      }

      public void OnAfterDeserialize() { }



      private bool   ValidID()                  => !string.IsNullOrWhiteSpace(ID) && Unique();
      private bool   Unique()                   => !FindObjectsByType<UniqueID>(FindObjectsSortMode.None).Any(HaveSameID);
      private bool   HaveSameID(UniqueID other) => other != this && other.ID == ID;
      private string GenerateID()               => $"{SceneName()}_{GUID.Generate()}";
      private string SceneName()                => gameObject.scene.name;
      private bool   Prefab()                   => gameObject.scene.rootCount == 0;
#endif
   }
}