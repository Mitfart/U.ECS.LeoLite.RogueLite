using Engine.Ecs;
using Events;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UnityIntegration.Plugins.Mitfart.LeoECSLite.UnityIntegration.Runtime;
using Mitfart.LeoECSLite.UnityIntegration.Plugins.Mitfart.LeoECSLite.UnityIntegration.Runtime.Name;
using Movement;
using Player;
using UnityRef;

public class MainSystemsPack : EcsSystemsPack {
  protected override void RegisterSystems() {
    AddPack<GetUnityDataSystems>();
    
    AddPack<PlayerSystems>();

    AddPack<MovementSystems>();
    AddPack<SetUnityDataSystems>();

    AddPack<ClearEventsPack>();
    Add<ConvertSceneSys>();

    AddWorldsDebug();
  }

  private void AddWorldsDebug() {
#if UNITY_EDITOR
    AddByInstance(new EcsWorldDebugSystem(nameSettings: new NameSettings(bakeComponents: true)));
#endif
  }
}