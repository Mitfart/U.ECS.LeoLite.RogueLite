using Infrastructure.AssetsManagement;

namespace Infrastructure.Factories {
   public abstract class Factory : IFactory {
      protected readonly IAssets Assets;
      
      public Factory(IAssets assets) {
         Assets = assets;
      }

      public abstract void Reset();
   }
}