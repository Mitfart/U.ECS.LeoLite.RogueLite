using Engine.Ecs;
using Gameplay.UnityRef.Transform.Sys;

namespace Gameplay.UnityRef {
   public class GetUnityDataSystems : EcsSystemsPack {
      protected override void RegisterSystems() => Add<GetTransformSys>();
   }
}