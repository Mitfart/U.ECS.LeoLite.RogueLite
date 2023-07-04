using Leopotam.EcsLite;

namespace Extensions.Ecs {
   public static class EntityIsAliveExt {
      public static bool IsAlive(this int entity, EcsWorld @in)
         => @in    != null
         && entity >= 0
         && entity < @in.GetEntitiesCount()
         && @in.IsAlive()
         && @in.GetEntityGen(entity) > 0;
   }
}