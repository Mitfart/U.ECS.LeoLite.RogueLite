using Leopotam.EcsLite;

namespace Extensions.Ecs {
   public static class EntityIsAliveExt {
      public static bool IsAlive(this int entity, EcsWorld @in)
         => @in.IsAlive()
         && @in.GetEntityGen(entity) > 0;
   }
}