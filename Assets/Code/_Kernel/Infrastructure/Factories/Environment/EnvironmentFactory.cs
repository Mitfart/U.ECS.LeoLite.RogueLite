using System.Collections.Generic;
using Gameplay.Level;
using Gameplay.Level.ecs.tmp.Comp;
using Gameplay.Level.StaticData;
using Infrastructure.AssetsManagement;
using Leopotam.EcsLite;
using UnityEngine;

namespace Infrastructure.Factories {
   public class EnvironmentFactory : Factory {
      private const string _CONTAINER_NAME = "Environment";
      private const string _DOORS_TAG      = "Doors";

      private readonly EcsWorld _world;

      private readonly List<DoorAdapter> _doors;



      public EnvironmentFactory(IAssets assets, EcsWorld world) : base(assets) {
         _world = world;
         _doors = new List<DoorAdapter>();
      }

      public override void Reset() {
         base.Reset();

         _doors.Clear();
      }



      public DoorAdapter CreateDoor(Vector3 at, Location nextLocation, Room nextRoom) => CreateDoor(at, new NextLevel(nextLocation, nextRoom));

      public DoorAdapter CreateDoor(Vector3 at, NextLevel nextLevel) {
         DoorAdapter doorIns = Assets.Ins<DoorAdapter>(
            AssetPath.DOOR,
            at,
            Quaternion.identity,
            Container(_CONTAINER_NAME, _DOORS_TAG)
         );

         doorIns.component.NextLevel = nextLevel;

         doorIns.Converter.Convert(_world, _world.NewEntity());

         Cache(doorIns);
         return doorIns;
      }



      private void Cache(DoorAdapter doorIns) => _doors.Add(doorIns);
   }
}