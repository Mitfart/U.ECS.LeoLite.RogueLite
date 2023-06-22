using System.Collections.Generic;
using UnityEngine;

namespace Level {
  [CreateAssetMenu]
  public class LocationsDB : ScriptableObject {
    [SerializeField] private Location[] locations;

    public IReadOnlyList<Location> Read() => locations;
  }
}