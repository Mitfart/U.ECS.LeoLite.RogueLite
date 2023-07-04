using Extensions.Ecs;
using Gameplay.Unit.Behavior.Comps;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Infrastructure.Factories.Extensions {
   public static class EnemyWithoutAIExt {
      public static void WithoutAI(this ConvertToEntity enemy) {
         if (enemy.IsConverted) {
            enemy.World
                 .GetPool<Behavior>()
                 .TryDel(enemy.Entity);
            return;
         }

         if (enemy.TryGetComponent(out BehaviorProv behaviorProv))
            Object.Destroy(behaviorProv);
      }
   }
}