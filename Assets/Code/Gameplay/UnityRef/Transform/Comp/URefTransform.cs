using System;
using Gameplay.UnityRef.Abstract;
using UnityEngine;

namespace Gameplay.UnityRef.Transform.Comp {
   [Serializable]
   public struct URefTransform : IEcsURef<UnityEngine.Transform> {
      [field: SerializeField] public UnityEngine.Transform Component { get; set; }
   }
}