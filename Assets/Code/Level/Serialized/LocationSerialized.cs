#if UNITY_EDITOR
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Level {
   public partial class Location : ISerializationCallbackReceiver {
      [SerializeField] private List<SceneAsset> defaultRooms = new();
      [SerializeField] private List<SceneAsset> secretRooms  = new();
      [SerializeField] private List<SceneAsset> shopRooms    = new();



      public void OnBeforeSerialize() {
         Convert(defaultRooms, out defaultRoomsNames);
         Convert(secretRooms,  out secretRoomsNames);
         Convert(shopRooms,    out shopRoomsNames);

         EditorUtility.SetDirty(this);
      }

      public void OnAfterDeserialize() { }



      private static void Convert(IReadOnlyList<SceneAsset> sceneAssets, out string[] rooms) {
         rooms = default;
         if (sceneAssets == null) return;

         int count = sceneAssets.Count;

         rooms = new string[count];

         for (var i = 0; i < count; i++) rooms[i] = !sceneAssets[i].IsUnityNull() ? sceneAssets[i].name : string.Empty;
      }
   }
}
#endif