using System;
using UnityEngine.SceneManagement;

namespace Infrastructure.Loading {
   public interface ISceneLoader {
      void Load(
         string        name,
         Action<Scene> onLoaded  = null,
         Action<float> onLoading = null
      );
   }
}