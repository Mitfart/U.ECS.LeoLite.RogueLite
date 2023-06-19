#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Debug {
  public class GizmosService : MonoBehaviour {
    private HashSet<Action> _prevToDraw;
    private HashSet<Action> _toDraw;

    public bool IsActive { get; private set; }
    public bool IsPaused { get; private set; }

    // hack: only knowing way to check for pause in the same frame
    private void LateUpdate() => IsPaused = false;



    private void OnEnable()  => On();
    private void OnDisable() => Off();



    private void OnDrawGizmos() {
      if (!IsActive)
        return;

      if (IsPaused)
        DrawPrev();

      foreach (Action drawAction in _toDraw) {
        drawAction.Invoke();
        ResetGizmos();
      }

      DrawPrev();
      _toDraw.Clear();
      IsPaused = true;
    }



    public void Draw(Action draw) {
      if (IsActive)
        _toDraw.Add(draw);
    }



    public void On() {
      if (IsActive)
        return;

      IsActive    = true;
      _toDraw     = new HashSet<Action>();
      _prevToDraw = new HashSet<Action>();
    }

    public void Off() {
      if (!IsActive)
        return;

      IsActive = false;
      _toDraw.Clear();
      _prevToDraw.Clear();
      _toDraw     = null;
      _prevToDraw = null;
    }

    public void Toggle() {
      if (IsActive)
        Off();
      else
        On();
    }



    private void DrawPrev() {
      (_prevToDraw, _toDraw) = (_toDraw, _prevToDraw);
    }

    private static void ResetGizmos() {
      Gizmos.color  = Color.white;
      Gizmos.matrix = Matrix4x4.identity;
    }
  }
}
#endif