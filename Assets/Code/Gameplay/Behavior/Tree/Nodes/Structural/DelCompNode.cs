using Leopotam.EcsLite;

namespace Gameplay.Unit.Behavior.Tree.Nodes.Structural {
   public class DelCompNode<TComp> : BehaviorNode where TComp : struct {
      private EcsPool<TComp> _tCompPool;

      protected override void OnInit()  => _tCompPool = World.GetPool<TComp>();
      protected override void OnBegin() => _tCompPool.Del(Entity);
   }
}