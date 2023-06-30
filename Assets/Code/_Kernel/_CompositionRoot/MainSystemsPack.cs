using ECS.Battle;
using ECS.Destroy;
using ECS.Movement;
using ECS.Player.Comps;
using ECS.Unit;
using ECS.UnityRef;
using ECS.View;
using ECS.Weapon;
using Engine.Ecs;
using Events;
using Mitfart.LeoECSLite.UniLeo;
using Mitfart.LeoECSLite.UnityIntegration;
using Mitfart.LeoECSLite.UnityIntegration.Name;

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
      var nameSettings = new NameSettings(bakeComponents: true);
      AddByInstance(new EcsWorldDebugSystem(nameSettings: nameSettings));
#endif
   }
}