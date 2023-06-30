using Leopotam.EcsLite;

namespace ECS.Unit.Behavior.Nodes {
   public abstract class BehaviorNode {
      public    bool           IsActive   { get; private set; }
      public    BehaviorState  CurState   { get; private set; } = BehaviorState.Run;
      protected BehaviorNode[] ChildNodes { get; }



      protected BehaviorNode(params BehaviorNode[] childNodes) {
         ChildNodes = childNodes;
      }



      public BehaviorState Run(int e, EcsWorld world) {
         Begin(e, world);
         CurState = OnRun(e, world);
         Finish(e, world);

         return CurState;
      }

      private void Begin(int e, EcsWorld world) {
         if (IsActive) return;

         IsActive = true;
         OnBegin(e, world);
      }

      private void Finish(int e, EcsWorld world) {
         if (CurState == BehaviorState.Run) return;

         IsActive = false;
         OnFinish(e, world);
      }



      protected virtual BehaviorState OnRun(int e, EcsWorld world) {
         BehaviorState finalState = BehaviorState.Success;

         foreach (BehaviorNode node in ChildNodes) {
            BehaviorState childState = node.Run(e, world);

            if (childState == BehaviorState.Run) finalState = BehaviorState.Run;
         }

         return finalState;
      }

      protected virtual void OnBegin(int  e, EcsWorld world) { }
      protected virtual void OnFinish(int e, EcsWorld world) { }
   }
}