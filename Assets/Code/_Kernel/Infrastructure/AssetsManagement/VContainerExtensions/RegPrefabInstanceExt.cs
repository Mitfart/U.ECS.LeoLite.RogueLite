using Infrastructure.AssetsManagement;
using UnityEngine;
using VContainer;

namespace Extensions.VContainer {
   public static class RegPrefabInstanceExt {
      public static void RegPrefabInstance<TAsset>(this IContainerBuilder di, string path) where TAsset : Object {
         di.Register(
               r => {
                  TAsset ins = r.Resolve<IAssets>().Ins<TAsset>(path);
                  Object.DontDestroyOnLoad(ins);
                  return ins;
               },
               Lifetime.Singleton
            )
           .AsSelf()
           .AsImplementedInterfaces();

         di.RegisterBuildCallback(r => r.Resolve<TAsset>());
      }
   }
}