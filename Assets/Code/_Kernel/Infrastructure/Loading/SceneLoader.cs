using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Loading {
   public class SceneLoader : ISceneLoader {
      public async void Load(
         string        name,
         Action<Scene> onLoaded  = null,
         Action<float> onLoading = null
      )
         => await LoadScene(name, onLoaded, onLoading);



      private static async Task LoadScene(
         string        name,
         Action<Scene> onLoaded,
         Action<float> onLoading
      ) {
         AsyncOperation loadOperation = SceneManager.LoadSceneAsync(name);

         while (!loadOperation.isDone) {
            onLoading?.Invoke(loadOperation.progress);
            await Task.Delay(millisecondsDelay: 10);
         }

#if UNITY_EDITOR
         if (!Application.isPlaying) // prevent from switching / deleting scene after exit playmode
            return;
#endif

         Scene loadedScene = SceneManager.GetSceneByName(name);
         SceneManager.SetActiveScene(loadedScene);

         onLoaded?.Invoke(loadedScene);
      }



      private static bool AlreadyLoaded(string sceneName, out Scene scene) => (scene = SceneManager.GetActiveScene()).name.Equals(sceneName);
   }
}