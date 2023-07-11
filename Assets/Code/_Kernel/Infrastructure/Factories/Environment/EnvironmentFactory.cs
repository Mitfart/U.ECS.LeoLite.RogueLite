using System.Collections.Generic;
using Gameplay.Level;
using Gameplay.Level.StaticData;
using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factories {
   public class EnvironmentFactory : Factory {
      private const string _CONTAINER_NAME = "Environment";
      private const string _DOORS_TAG      = "Doors";

      private readonly List<GameObject> _doors;



      public EnvironmentFactory(IAssets assets) : base(assets) {
         _doors = new List<GameObject>();
      }

      public override void Reset() {
         base.Reset();

         _doors.Clear();
      }



      public GameObject CreateDoor(Vector3 at, Location nextLocation, Room nextRoom) => CreateDoor(at, new NextLevel(nextLocation, nextRoom));

      public GameObject CreateDoor(Vector3 at, NextLevel nextLevel) {
         GameObject doorIns = Assets.Ins<GameObject>(
            AssetPath.DOOR,
            at,
            Quaternion.identity,
            Container(_CONTAINER_NAME, _DOORS_TAG)
         );
         //doorIns.component.NextLevel = nextLevel;

         Cache(doorIns);
         return doorIns;
      }



      private void Cache(GameObject doorIns) => _doors.Add(doorIns);
   }
}