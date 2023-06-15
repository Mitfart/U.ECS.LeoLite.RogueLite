using System;
using Mitfart.LeoECSLite.UniLeo.Providers;
using UnityEngine;
using UnityEngine.UIElements;

namespace Battle.UI {
  [DisallowMultipleComponent] public class HealthBarProv : EcsProvider<HealthBar> { }

  [Serializable]
  public struct HealthBar {
    public ProgressBar Bar;
  }
}