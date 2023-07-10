using System;
using System.Collections.Generic;
using System.Linq;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Gameplay.View.Comps {
   [Serializable]
   public struct Views {
      public List<EcsView> value;
   }
}