using Leopotam.EcsLite;

namespace Behavior.Nodes.Special.Weapon {
  public class DelCompNode<TComp> : BehaviorNode where TComp : struct {
    protected override BehaviorState OnRun(int e, EcsWorld world) {
      world.GetPool<TComp>().Del(e);
      return base.OnRun(e, world);
    }
  }
}