using System;
using Level.StaticData;
using UnityEngine;
using Mitfart.LeoECSLite.UniLeo.Providers;

namespace Level {
   [DisallowMultipleComponent] public class DoorProv : EcsProvider<Door> { }

   [Serializable]
   public struct Door {
      public Location NextLocation;
      public Room     NextRoom;
   }
}