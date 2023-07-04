﻿using Infrastructure.AssetsManagement;

namespace Infrastructure.Factories {
   public abstract class Factory {
      protected readonly IAssets Assets;
      
      public Factory(IAssets assets) {
         Assets = assets;
      }
   }
}