using Engine.Ecs;
using Events;
using Features.Battle;
using Features.Destroy;
using Features.Movement;
using Features.Player;
using Features.Unit;
using Features.View;
using Features.Weapon;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UnityIntegration;
using Mitfart.LeoECSLite.UnityIntegration.Name;
using UnityRef;

public class MainSystemsPack : EcsSystemsPack {
  protected override void RegisterSystems() {
    Add<ConvertSceneSys>();
    AddPack<GetUnityDataSystems>();

    AddPack<PlayerSystems>();
    AddPack<MovementSystems>();
    AddPack<WeaponSystems>();
    AddPack<BattleSystems>();
    AddPack<UnitSystems>();

    AddPack<ViewSystems>();
    AddPack<SetUnityDataSystems>();
    Add<DestroySys>();

    AddPack<ClearEventsPack>();

    AddWorldsDebug();
  }

  private void AddWorldsDebug() {
#if UNITY_EDITOR
    var nameSettings = new NameSettings(true);
    AddByInstance(new EcsWorldDebugSystem(nameSettings: nameSettings));
#endif
  }
}