#if UNITY_EDITOR
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level {
   public partial class Location : ISerializationCallbackReceiver {
      [SerializeField] private List<SceneAsset> defaultRoomsScenes = new();
      [SerializeField] private List<SceneAsset> secretRoomsScenes  = new();
      [SerializeField] private List<SceneAsset> shopRoomsScenes    = new();



      public void OnBeforeSerialize() {
         Convert(defaultRoomsScenes, out defaultRooms);
         Convert(secretRoomsScenes,  out secretRooms);
         Convert(shopRoomsScenes,    out shopRooms);

         EditorUtility.SetDirty(this);
      }

      public void OnAfterDeserialize() { }



      private static void Convert(IReadOnlyList<SceneAsset> scenes, out Room[] rooms) {
         rooms = default;
         /*
            
            if (scenes == null) return;
   
            int count = scenes.Count;
            rooms = new Room[count];
   
            for (var i = 0; i < count; i++)
               rooms[i] = !scenes[i].IsUnityNull()
                  ? SceneManager.
                  : null;
         */
      }
   }
}
#endif