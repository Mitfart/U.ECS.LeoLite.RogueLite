using Leopotam.EcsLite;

namespace Gameplay.Unit.Behavior.Nodes.Debug {
   public class LogNode : BehaviorNode {
      private readonly string _massage;



      public LogNode(string massage, params BehaviorNode[] childNodes) : base(childNodes) {
         _massage = massage;
      }

      protected override void OnBegin(int e, EcsWorld world) {
#if UNITY_EDITOR
         UnityEngine.Debug.Log($"{_massage}__({e})_({world})");
#endif
      }
   }
}