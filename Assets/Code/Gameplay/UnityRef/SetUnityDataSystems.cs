using Engine.Ecs;
using Gameplay.UnityRef.Transform.Sys;

namespace Gameplay.UnityRef {
   public class SetUnityDataSystems : EcsSystemsPack {
      protected override void RegisterSystems() => Add<SetTransformSys>();
   }
}