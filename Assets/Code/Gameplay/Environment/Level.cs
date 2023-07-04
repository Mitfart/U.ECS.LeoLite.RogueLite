using System.Collections.Generic;
using Gameplay.Environment.StaticData;

namespace Gameplay.Environment {
   public class Level {
      private readonly List<Location> _passedLocations;
      private readonly List<Room>     _passedRooms;

      public IReadOnlyList<Location> PassedLocations => _passedLocations;
      public IReadOnlyList<Room>     PassedRooms     => _passedRooms;

      public Location Location { get; private set; }
      public Room     Room     { get; private set; }



      public Level() {
         _passedLocations = new List<Location>(capacity: 4);
         _passedRooms     = new List<Room>(capacity: 4);
      }



      public void SetLocation(Location location) {
         Location = location;
         _passedLocations.Add(location);
      }

      public void SetRoom(Room room) {
         Room = room;
         _passedRooms.Add(room);
      }
   }
}