using System;

namespace Infrastructure.Loading {
  public interface ISceneLoader {
    void Load(
      string        name,
      Action        onLoaded  = null,
      Action<float> onLoading = null
    );
  }
}