using System;
using System.Collections.Generic;
using System.Linq;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.View.Comps {
   [DisallowMultipleComponent]
   public class ViewsProv : EcsProvider<Views> {
      private void OnValidate() {
         if (component.value != null)
            component.value = component.value.ToHashSet().ToList();
      }
   }

   [Serializable]
   public struct Views {
      public List<EcsView> value;
   }
}