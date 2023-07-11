using Gameplay.Unit.Behavior.ECS.Comps;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Unit.Behavior.Nodes.Movement {
   public class DoMoveToTarget : DoMoveToNode {
      private EcsPool<Target> _targetPool;



      protected override void OnInit() {
         base.OnInit();
         _targetPool = World.GetPool<Target>();
      }
      
      protected override Vector3 Destination()
         => _targetPool.Get(Entity).Value.Unpack(out _, out int targetE)
            ? Position(targetE)
            : Position(Entity);

   }
}