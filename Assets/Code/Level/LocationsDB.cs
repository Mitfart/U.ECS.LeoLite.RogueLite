using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level {
   [CreateAssetMenu]
   public class LocationsDB : ScriptableObject, IReadOnlyList<Location> {
      [SerializeField] private List<Location> locations;

      public int Count => locations.Count;
      public Location this[int index] => locations[index];
      public IEnumerator<Location> GetEnumerator() => locations.GetEnumerator();
      IEnumerator IEnumerable.     GetEnumerator() => GetEnumerator();
   }
}