using System.Collections.Generic;
using Gameplay.Environment;
using Gameplay.Environment.ecs.Comp;
using Gameplay.Environment.StaticData;
using Infrastructure.AssetsManagement;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Infrastructure.Factories {
   public class EnvironmentFactory : Factory {
      private readonly List<ConvertToEntity> _doors;



      public EnvironmentFactory(IAssets assets) : base(assets) {
         _doors = new List<ConvertToEntity>();
      }

      public DoorProv CreateDoor(Vector3 at, NextLevel nextLevel) {
         DoorProv doorIns = Assets.Ins<DoorProv>(AssetPath.DOOR, at);
         doorIns.component.NextLevel = nextLevel;

         _doors.Add(doorIns.GetComponent<ConvertToEntity>());
         return doorIns;
      }

      public DoorProv CreateDoor(Vector3 at, Location nextLocation, Room nextRoom) => CreateDoor(at, new NextLevel(nextLocation, nextRoom));
   }
}