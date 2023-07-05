using System.Collections.Generic;
using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factories {
   public abstract class Factory : IFactory {
      protected readonly IAssets Assets;

#if UNITY_EDITOR
      private readonly Dictionary<string, Transform> _containers;
#endif



      public Factory(IAssets assets) {
         Assets = assets;
#if UNITY_EDITOR
         _containers = new Dictionary<string, Transform>();
#endif
      }

      public virtual void Reset() => _containers.Clear();



      protected Transform Container(string name, string key = null) {
#if UNITY_EDITOR
         key = ValidKey(key);

         if (!_containers.ContainsKey(key))
            _containers.Add(key, CreateContainer(name, key));

         return _containers[key];
#else
         return null;
#endif
      }

#if UNITY_EDITOR
      private static string ValidKey(string key)
         => string.IsNullOrWhiteSpace(key)
            ? string.Empty
            : key;

      private static Transform CreateContainer(string name, string key)
         => string.IsNullOrWhiteSpace(key)
            ? new GameObject($"| {name} |").transform
            : new GameObject($"| {name} |__| {key} |").transform;
#endif
   }
}