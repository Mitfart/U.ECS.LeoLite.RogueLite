using System;
using UnityEngine;

namespace Movement.Smooth {
  [Serializable]
  // Explaination: https://www.youtube.com/watch?v=KPoeNZZ6H4s&t=105s
  public class SmoothVector3 {
    private Vector3 _deltaState;

    private float _k1, _k2, _k3;


    private Vector3 _prevInput;

    public Vector3 State { get; private set; }

    public float Freaquency {
      get => frequency;
      set {
        frequency = value;
        ReCalcK();
      }
    }

    public float Damping {
      get => damping;
      set {
        damping = value;
        ReCalcK();
      }
    }

    public float Responsiveness {
      get => responsiveness;
      set {
        responsiveness = value;
        ReCalcK();
      }
    }



    public void Init(Vector3 input) {
      _prevInput = input;
      State      = input;
      ReCalcK();
    }

    // Explaination: https://www.youtube.com/watch?v=KPoeNZZ6H4s&t=105s
    public Vector3 Update(float delta, Vector3 input, Vector3? deltaInput = null) {
      Calc(input, CalcDeltaInput(input, delta), delta);
      return State;
    }



    private Vector3 CalcDeltaInput(Vector3 input, float delta) {
      Vector3 deltaInput = (input - _prevInput) / delta;
      _prevInput = input;
      return deltaInput;
    }

    private void Calc(Vector3 input, Vector3 deltaInput, float delta) {
      State       += delta * _deltaState;
      _deltaState += delta * KDeltaState(input, deltaInput, delta);
    }

    private Vector3 KDeltaState(Vector3 input, Vector3 deltaInput, float delta) => (KInput(input, deltaInput) - KState()) / K2Stable(delta);
    private Vector3 KInput(Vector3      input, Vector3 deltaInput) => input + _k3 * deltaInput;
    private Vector3 KState() => State + _k1 * _deltaState;

    private float K2Stable(float delta)
      => Mathf.Max(
        _k2,
        delta * ((delta + _k1) * .5f),
        delta * _k1
      );

    private void ReCalcK() {
      float piF  = Mathf.PI * frequency;
      float piF2 = piF      * 2f;

      _k1 = damping                  / piF;
      _k2 = 1                        / (piF2 * piF2);
      _k3 = responsiveness * damping / piF2;
    }

// @formatter:off
    [SerializeField][Range(.01f, 15f)] private float frequency = 5f;
    [SerializeField][Range(.01f,  1f)] private float damping   = .5f;
    [SerializeField][Range( -5f,  5f)] private float responsiveness;
// @formatter:on
  }
}