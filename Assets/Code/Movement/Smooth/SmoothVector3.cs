using System;
using UnityEngine;

namespace Movement {
  [Serializable]
  // Explaination: https://www.youtube.com/watch?v=KPoeNZZ6H4s&t=105s
  public class SmoothVector3 {
// @formatter:off
    private const float MIN_FREQUENCY      = .01f;  private const float MAX_FREQUENCY      = 15f;
    private const float MIN_DAMPING        = .01f;  private const float MAX_DAMPING        = 1f;
    private const float MIN_RESPONSIVENESS = -5f;   private const float MAX_RESPONSIVENESS = 5f;

    [SerializeField][Range(MIN_FREQUENCY,      MAX_FREQUENCY)]      private float frequency = 5f;
    [SerializeField][Range(MIN_DAMPING,        MAX_DAMPING)]        private float damping   = .5f;
    [SerializeField][Range(MIN_RESPONSIVENESS, MAX_RESPONSIVENESS)] private float responsiveness;
// @formatter:on

    public Vector3 State => _state;

    public float Freaquency {
      get => frequency;
      set {
        frequency = Mathf.Clamp(value, MIN_FREQUENCY, MAX_FREQUENCY);
        ReCalcK();
      }
    }

    public float Damping {
      get => damping;
      set {
        damping = Mathf.Clamp(value, MIN_DAMPING, MAX_DAMPING);
        ReCalcK();
      }
    }

    public float Responsiveness {
      get => responsiveness;
      set {
        responsiveness = Mathf.Clamp(value, MIN_RESPONSIVENESS, MAX_RESPONSIVENESS);
        ReCalcK();
      }
    }


    private Vector3 _prevInput;
    private Vector3 _state;
    private Vector3 _deltaState;

    private float _k1, _k2, _k3;



    public void Init(Vector3 input) {
      _prevInput = input;
      _state     = input;
      ReCalcK();
    }

    // Explaination: https://www.youtube.com/watch?v=KPoeNZZ6H4s&t=105s
    public Vector3 Update(float delta, Vector3 input, Vector3? deltaInput = null) {
      Calc(input, CalcDeltaInput(input, delta), delta);
      return _state;
    }



    private Vector3 CalcDeltaInput(Vector3 input, float delta) {
      Vector3 deltaInput = (input - _prevInput) / delta;
      _prevInput = input;
      return deltaInput;
    }

    private void Calc(Vector3 input, Vector3 deltaInput, float delta) {
      _state      += delta * _deltaState;
      _deltaState += delta * KDeltaState(input, deltaInput, delta);
    }

    private Vector3 KDeltaState(Vector3 input, Vector3 deltaInput, float delta) => (KInput(input, deltaInput) - KState()) / K2Stable(delta);
    private Vector3 KInput(Vector3      input, Vector3 deltaInput) => input + _k3 * deltaInput;
    private Vector3 KState() => _state + _k1 * _deltaState;

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
  }
}