using Extensions.UnityObject;
using UnityEngine;
using VContainer;

namespace Infrastructure.AssetsManagement.VContainerExtensions {
   public static class RegPrefabInstanceExt {
      public static void RegInstance<TAsset>(this IContainerBuilder di, string path) where TAsset : Object
         => di.Register(
                  r =>
                     r.Resolve<IAssets>()
                      .Ins<TAsset>(path)
                      .DontDestroy(),
                  Lifetime.Singleton
               )
              .AsSelf()
              .AsImplementedInterfaces();

      public static void RegInstanceInstantly<TAsset>(this IContainerBuilder di, string path) where TAsset : Object {
         di.RegInstance<TAsset>(path);
         di.ResolveOnBuild<TAsset>();
      }
   }
}