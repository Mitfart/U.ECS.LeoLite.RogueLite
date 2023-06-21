using Debug;
using Infrastructure.Loading;
using Level;
using UnityEngine;

namespace Infrastructure.AssetsManagement {
  public sealed class Assets {
    public GizmosService  GizmosService  { get; }
    public LoadingCurtain LoadingCurtain { get; }
    public LocationsDB    Locations      { get; }
    public Object         Render         { get; }

    public Assets() {
      GizmosService  = Resources.Load<GizmosService>(ResourcesPath.GIZMOS_SERVICE);
      LoadingCurtain = Resources.Load<LoadingCurtain>(ResourcesPath.LOADING_CURTAIN);
      Locations      = Resources.Load<LocationsDB>(ResourcesPath.LOCATIONS);
      Render         = Resources.Load(ResourcesPath.RENDER);
    }


    public GizmosService  InsGizmosService()  => Instantiate(GizmosService);
    public LoadingCurtain InsLoadingCurtain() => Instantiate(LoadingCurtain);
    public Object         InsRender()         => Instantiate(Render);

    private static T Instantiate<T>(T asset) where T : Object => Object.Instantiate(asset);
  }
}