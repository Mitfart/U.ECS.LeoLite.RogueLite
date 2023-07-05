using Leopotam.EcsLite;

namespace Gameplay.Unit.Behavior.Nodes.Structural {
   public class AddCompNode<TComp> : BehaviorNode where TComp : struct {
      private EcsPool<TComp> _tCompPool;

      protected override void OnInit()  => _tCompPool = World.GetPool<TComp>();
      protected override void OnBegin() => _tCompPool.Add(Entity);
   }
}