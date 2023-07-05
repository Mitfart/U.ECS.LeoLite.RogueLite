using System.Collections.Generic;
using Gameplay.Environment;
using Gameplay.Environment.ecs.Comp;
using Gameplay.Environment.StaticData;
using Infrastructure.AssetsManagement;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Infrastructure.Factories {
   public class EnvironmentFactory : Factory {
      private const string _CONTAINER_NAME = "Environment";
      private const string _DOORS_TAG      = "Doors";

      private readonly List<ConvertToEntity> _doors;



      public EnvironmentFactory(IAssets assets) : base(assets) {
         _doors = new List<ConvertToEntity>();
      }

      public override void Reset() {
         base.Reset();

         _doors.Clear();
      }



      public DoorProv CreateDoor(Vector3 at, Location nextLocation, Room nextRoom) => CreateDoor(at, new NextLevel(nextLocation, nextRoom));

      public DoorProv CreateDoor(Vector3 at, NextLevel nextLevel) {
         DoorProv doorIns = Assets.Ins<DoorProv>(
            AssetPath.DOOR,
            at,
            Quaternion.identity,
            Container(_CONTAINER_NAME, _DOORS_TAG)
         );
         doorIns.component.NextLevel = nextLevel;

         Cache(doorIns);
         return doorIns;
      }



      private void Cache(DoorProv doorIns) => _doors.Add(doorIns.GetComponent<ConvertToEntity>());
   }
}