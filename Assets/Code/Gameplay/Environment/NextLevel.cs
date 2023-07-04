using Gameplay.Environment.StaticData;

namespace Gameplay.Environment {
   public struct NextLevel {
      public readonly Location Location;
      public readonly Room     Room;

      public NextLevel(Location location, Room room) {
         Location = location;
         Room     = room;
      }

      public override string ToString() => $"{Location.Title}_{Room.RoomType}_{Room.SceneName}";
   }
}