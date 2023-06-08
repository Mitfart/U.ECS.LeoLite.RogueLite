using Events;
using Extentions;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UnityIntegration.Plugins.Mitfart.LeoECSLite.UnityIntegration.Runtime;
using Mitfart.LeoECSLite.UnityIntegration.Plugins.Mitfart.LeoECSLite.UnityIntegration.Runtime.Name;

public class MainSystemsPack : EcsSystemsPack {
  protected override void RegisterSystems() {
    /*
    AddPack<DestroySystems>();

    AddPack<GetMonoDataSystems>();

    Add<TestPlayerInputSys>(); // *************************
    Add<ProcessBehaviorSys>(); // *************************
    Add<TestAISys>();          // *************************

    AddPack<MovementSystems>();
    AddPack<UnitSystems>();
    AddPack<WeaponSystems>();
    AddPack<BattleSystems>();

    AddPack<CameraShakeSystems>();

    AddPack<SetMonoDataSystems>();
    */

    AddPack<DestroyEvents>();
    Add<ConvertSceneSys>();

    AddWorldsDebug();
  }

  private void AddWorldsDebug() {
#if UNITY_EDITOR
    AddByInstance(
      new EcsWorldDebugSystem(
        nameSettings: new NameSettings(
          bakeComponents: true)));
#endif
  }
}