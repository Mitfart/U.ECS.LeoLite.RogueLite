using Extensions.Ecs;
using Gameplay.Unit.Behavior.ECS.Comps;
using Leopotam.EcsLite;

namespace Infrastructure.Factories {
   public static class WithoutAIExt {
      public static int WithoutAI(this int entity, EcsWorld world) {
         if (entity.IsAlive(world))
            world
              .GetPool<AI>()
              .TryDel(entity);

         return entity;
      }
   }
}