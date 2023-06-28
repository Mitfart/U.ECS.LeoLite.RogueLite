using Infrastructure.AssetsManagement;
using UnityEngine;
using VContainer;

namespace Extensions.VContainer {
   public static class RegScriptableExt {
      public static void RegScriptable<TAsset>(this IContainerBuilder di, string path) where TAsset : ScriptableObject {
         di
           .Register(r => r.Resolve<IAssets>().Load<TAsset>(path), Lifetime.Singleton)
           .AsImplementedInterfaces()
           .AsSelf()
            ;
      }
   }
}