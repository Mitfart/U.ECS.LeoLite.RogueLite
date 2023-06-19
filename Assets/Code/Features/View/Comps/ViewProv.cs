using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;

namespace Features.View {
  [DisallowMultipleComponent] public class ViewProv : EcsProvider<View> { }

  [Serializable]
  public struct View {
    public IEvsView value;
  }
}