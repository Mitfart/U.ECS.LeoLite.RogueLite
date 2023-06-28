using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace ECS.View {
   [DisallowMultipleComponent] public class ViewProv : EcsProvider<View> { }

   [Serializable]
   public struct View {
      public EcsView value;
   }
}