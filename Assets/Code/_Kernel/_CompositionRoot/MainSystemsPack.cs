using Events;
using Extensions.Ecs;
using Gameplay.Destroy;
using Gameplay.HitBoxes;
using Gameplay.Level.ecs.tmp;
using Gameplay.Movement;
using Gameplay.Player;
using Gameplay.Unit;
using Gameplay.Unit.Behavior;
using Gameplay.UnityRef;
using Gameplay.View;
using Gameplay.Weapon;
using Mitfart.LeoECSLite.UnityIntegration;

public class MainSystemsPack : EcsSystemsPack {
   protected override void RegisterSystems() {
      AddPack<LevelSystems>();
      AddPack<GetUnityDataSystems>();

      AddPack<PlayerSystems>();
      AddPack<BehaviorSystems>();

      AddPack<WeaponSystems>();
      AddPack<MovementSystems>();
      AddPack<BattleSystems>();
      AddPack<UnitSystems>();

      AddPack<ViewSystems>();
      AddPack<SetUnityDataSystems>();
      AddPack<DestroySystems>();

      AddPack<ClearEventsPack>();

#if UNITY_EDITOR
      var nameSettings = new NameSettings(bakeComponents: true);
      AddByInstance(new EcsWorldDebugSystem(nameSettings: nameSettings));
#endif
   }
}