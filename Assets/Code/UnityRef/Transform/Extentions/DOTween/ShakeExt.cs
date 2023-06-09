using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using Leopotam.EcsLite;
using UnityEngine;

namespace UnityRef.Extentions.DOTween {
  public static class ShakeExt {
    public static Tweener GetShakePositionTween(
      this EcsPool<EcsTransform> pool,
      int                        entity,
      float                      duration,
      Vector3                    strength,
      int                        vibrato        = 10,
      float                      randomness     = 90f,
      bool                       snapping       = false,
      bool                       fadeOut        = true,
      ShakeRandomnessMode        randomnessMode = ShakeRandomnessMode.Harmonic
    ) {
      if (duration > 0.0)
        return DG.Tweening.DOTween.Shake(
                    () => pool.Get(entity).position,
                    x => pool.Get(entity).position = x,
                    duration,
                    strength,
                    vibrato,
                    randomness,
                    fadeOut,
                    randomnessMode
                  )
                 .SetOptions(snapping)
                 .SetUpdate(UpdateType.Manual)
                 .SetAutoKill(false);

      if (Debugger.logPriority > 0)
        UnityEngine.Debug.LogWarning("DOShakePosition: duration can't be 0, returning NULL without creating a tween");
      return null;
    }

    public static Tweener GetShakeRotationTween(
      this EcsPool<EcsTransform> pool,
      int                        entity,
      float                      duration,
      Vector3                    strength,
      int                        vibrato        = 10,
      float                      randomness     = 90f,
      bool                       fadeOut        = true,
      ShakeRandomnessMode        randomnessMode = ShakeRandomnessMode.Harmonic
    ) {
      if (duration > 0.0)
        return DG.Tweening.DOTween.Shake(
                    () => pool.Get(entity).EulerAngles,
                    x => pool.Get(entity).rotation = Quaternion.Euler(x),
                    duration,
                    strength,
                    vibrato,
                    randomness,
                    fadeOut,
                    randomnessMode
                  )
                 .SetSpecialStartupMode(SpecialStartupMode.SetShake)
                 .SetUpdate(UpdateType.Manual)
                 .SetAutoKill(false);

      if (Debugger.logPriority > 0)
        UnityEngine.Debug.LogWarning("DOShakeRotation: duration can't be 0, returning NULL without creating a tween");
      return null;
    }
  }
}