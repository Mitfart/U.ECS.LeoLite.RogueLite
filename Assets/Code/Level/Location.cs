using System.Collections.Generic;
using UnityEngine;

namespace Level {
   [CreateAssetMenu]
   public partial class Location : ScriptableObject {
      [field: SerializeField] public string Title { get; private set; }
      [field: SerializeField] public Color  Color { get; private set; }

      public List<MonoRoom> MonoRooms;

      [SerializeField, HideInInspector] private Room[] defaultRooms;
      [SerializeField, HideInInspector] private Room[] secretRooms;
      [SerializeField, HideInInspector] private Room[] shopRooms;

      public IReadOnlyList<Room> DefaultRooms => defaultRooms;
      public IReadOnlyList<Room> SecretRooms  => secretRooms;
      public IReadOnlyList<Room> ShopRooms    => shopRooms;

      // public Items[] Items;
   }
}