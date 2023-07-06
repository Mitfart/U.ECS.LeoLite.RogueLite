using Infrastructure.Factories;

namespace Infrastructure.AssetsManagement {
   public static class AssetPath {
      public const string BOOTSTRAP       = "Infrastructure/Bootstrap";
      public const string LOADING_CURTAIN = "Infrastructure/LoadingCurtain";

      public const string GIZMOS_SERVICE = "Services/GizmosService";
      public const string AI_NAV_SERVICE = "Services/AINavService";

      public const string RENDER = "Render";

      public const string START_LOCATION = "Location_Start";
      public const string DOOR           = "Door";
      public const string PLAYER         = "Player";

      public const string ENEMIES_FOLDER     = "Enemies";
      public const string PROJECTILES_FOLDER = "Projectiles";



      public static string ProjectilePath(string id) => $"{PROJECTILES_FOLDER}/{id}";
      public static string EnemyPath(EnemyType   id) => $"{ENEMIES_FOLDER}/{id}";
   }
}