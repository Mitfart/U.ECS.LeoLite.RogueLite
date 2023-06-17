using UnityEngine;

namespace Movement.Smooth {
  public class SmoothView : MonoBehaviour {
    public Transform     target;
    public SmoothVector3 value;



    private void Start()  => value.Init(target.position);
    private void Update() => transform.position = value.Update(Time.deltaTime, target.position);
  }
}