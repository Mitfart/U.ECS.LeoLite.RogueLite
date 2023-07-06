using System;
using Gameplay.Unit.Behavior.Tree;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;
using VContainer;

namespace Gameplay.Unit.Behavior.ECS.Comps {
   [DisallowMultipleComponent]
   public class AIProv : EcsScrProvider<AI, ScrTreeBehavior> {
      private IObjectResolver _di;

      [Inject] public void Construct(IObjectResolver di) => _di = di;

      protected override void Add(EcsPool<AI> pool, int e, EcsWorld world) {
         base.Add(pool, e, world);

         pool.Get(e)
             .Behavior
             .Init(e, world, _di);
      }
   }

   [Serializable]
   public struct AI {
      public BehaviorTree Behavior;
   }
}