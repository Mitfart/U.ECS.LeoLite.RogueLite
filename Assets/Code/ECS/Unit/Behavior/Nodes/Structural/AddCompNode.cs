using Leopotam.EcsLite;

namespace ECS.Unit.Behavior.Nodes.Structural {
   public class AddCompNode<TComp> : BehaviorNode where TComp : struct {
      protected override BehaviorState OnRun(int e, EcsWorld world) {
         world.GetPool<TComp>().Add(e);
         return base.OnRun(e, world);
      }
   }
}