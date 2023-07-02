using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Level.StaticData {
   [CreateAssetMenu]
   public class Location : ScriptableObject {
      [SerializeField]        private List<Location> nextLocations = new();
      [SerializeField]        private List<Room>     rooms         = new();
      [SerializeField]        private List<Room>     defaultRooms  = new();
      [SerializeField]        private List<Room>     secretRooms   = new();
      [SerializeField]        private List<Room>     shopRooms     = new();
      [SerializeField]        private List<Room>     bossRooms     = new();
      [field: SerializeField] public  string         Title { get; private set; }
      [field: SerializeField] public  Color          Color { get; private set; }

      public IReadOnlyList<Location> NextLocations => nextLocations;
      public IReadOnlyList<Room>     Rooms         => rooms;
      public IReadOnlyList<Room>     DefaultRooms  => defaultRooms;
      public IReadOnlyList<Room>     SecretRooms   => secretRooms;
      public IReadOnlyList<Room>     ShopRooms     => shopRooms;
      public IReadOnlyList<Room>     BossRooms     => bossRooms;



      public void StoreRoom(Room room) {
         if (AlreadyStored(room, out int i))
            rooms[i] = room;
         else
            rooms.Add(room);

         RefreshRoomsPools();
      }

      private bool AlreadyStored(Room room, out int index) {
         Room storedRoom = rooms.FirstOrDefault(storedRoom => storedRoom.ID == room.ID);
         bool stored     = storedRoom != null;

         index = stored
            ? rooms.IndexOf(storedRoom)
            : -1;

         return stored;
      }

      private void RefreshRoomsPools() {
         defaultRooms = rooms.Where(r => r.RoomType == RoomType.Default).ToList();
         secretRooms  = rooms.Where(r => r.RoomType == RoomType.Secret).ToList();
         shopRooms    = rooms.Where(r => r.RoomType == RoomType.Shop).ToList();
         bossRooms    = rooms.Where(r => r.RoomType == RoomType.Boss).ToList();
      }
   }
}