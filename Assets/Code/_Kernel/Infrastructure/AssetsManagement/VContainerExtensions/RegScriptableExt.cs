using UnityEngine;
using VContainer;

namespace Infrastructure.AssetsManagement.VContainerExtensions {
   public static class RegScriptableExt {
      public static void RegScriptable<TAsset>(this IContainerBuilder di, string path) where TAsset : ScriptableObject
         => di
           .Register(r => r.Resolve<IAssets>().Load<TAsset>(path), Lifetime.Singleton)
           .AsImplementedInterfaces()
           .AsSelf();
   }
}