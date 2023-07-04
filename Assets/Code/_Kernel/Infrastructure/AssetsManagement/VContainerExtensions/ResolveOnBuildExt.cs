using VContainer;

namespace Infrastructure.AssetsManagement.VContainerExtensions {
   public static class ResolveOnBuildExt {
      public static void ResolveOnBuild<T>(this IContainerBuilder di)
         => di.RegisterBuildCallback(
            r =>
               r.Resolve<T>()
         );
   }
}