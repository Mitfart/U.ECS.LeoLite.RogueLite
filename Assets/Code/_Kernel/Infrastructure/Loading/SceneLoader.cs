using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Loading {
  public class SceneLoader : ISceneLoader {
    public async void Load(string name, Action onLoaded = null, Action<float> onLoading = null) {
      await LoadScene(name, onLoaded);
    }


    private static async Task LoadScene(
      string        name,
      Action        onLoaded  = null,
      Action<float> onLoading = null
    ) {
      AsyncOperation loadOperation = SceneManager.LoadSceneAsync(name);

      while (!loadOperation.isDone) {
        onLoading?.Invoke(loadOperation.progress);
        await Task.Delay(100);
      }

#if UNITY_EDITOR
      if (!Application.isPlaying) // prevent from switching / deleting scene after exit playmode
        return;
#endif

      Scene loadedScene = SceneManager.GetSceneByName(name);
      SceneManager.SetActiveScene(loadedScene);

      onLoaded?.Invoke();
    }
  }
}