using System.Collections.Generic;

namespace Level {
   public class Stage {
      private readonly IReadOnlyList<Location> _locations;

      private readonly List<Location> _passedLocations;
      private readonly List<Room>     _passedRooms;

      public IReadOnlyList<Location> PassedLocations => _passedLocations;
      public IReadOnlyList<Room>     PassedRooms     => _passedRooms;

      public Location Location { get; private set; }
      public Room     Room     { get; private set; }



      public Stage(IReadOnlyList<Location> locations) {
         _locations       = locations;
         _passedLocations = new List<Location>(4);
         _passedRooms     = new List<Room>(4);
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