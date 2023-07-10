using Gameplay.Unit.Behavior.ECS.Comps;
using Leopotam.EcsLite;
using UnityEngine;

namespace Gameplay.Unit.Behavior.Nodes.Movement {
   public class DoMoveToRandomPosition : DoMoveToNode {
      private EcsPool<ViewRadius> _viewRadiusPool;

      private Vector3 _destination;


      protected override void OnInit() {
         base.OnInit();
         _viewRadiusPool = World.GetPool<ViewRadius>();
      }

      protected override void OnBegin() {
         do {
            _destination = RandomPosition();
         } while (!PathExist(_destination));
      }

      protected override Vector3 Destination() => _destination;



      private Vector3 RandomPosition()         => RelativeRandomPosition() + Position(Entity);
      private Vector3 RelativeRandomPosition() => (Vector3)Random.insideUnitCircle.normalized * ViewRadius();
      private float   ViewRadius()             => _viewRadiusPool.Get(Entity).value;
   }
}