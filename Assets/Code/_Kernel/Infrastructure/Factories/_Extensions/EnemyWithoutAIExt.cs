using Extensions.Ecs;
using Gameplay.Unit.Behavior.ECS.Comps;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Infrastructure.Factories {
   public static class EnemyWithoutAIExt {
      public static void WithoutAI(this ConvertToEntity enemy) {
         if (enemy.IsConverted) {
            enemy.World
                 .GetPool<AI>()
                 .TryDel(enemy.Entity);
            return;
         }

         if (enemy.TryGetComponent(out AIProv behaviorProv))
            Object.Destroy(behaviorProv);
      }
   }
}