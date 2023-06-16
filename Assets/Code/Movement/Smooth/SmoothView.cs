using UnityEngine;

namespace Movement.Smooth {
  public class SmoothView : MonoBehaviour {
    public Transform     target;
    public SmoothVector3 value;



    private void Start()  => value.Init(target.position);
    private void Update() => transform.position = value.Update(Time.deltaTime, target.position);



    private void OnDrawGizmos() {
      DrawDebug(Vector3.up);
      DrawDebug(Vector3.up * 2.5f);
      DrawDebug(Vector3.up * 5f);
    }

    private void DrawDebug(Vector3 moveVector) {
      const float DELTA = .02f;
      const float ITER  = 1 / DELTA;
      const float SCALE = 1;

      var smoothClone = new SmoothVector3 {
        Freaquency     = value.Freaquency,    //
        Damping        = value.Damping,       //
        Responsiveness = value.Responsiveness //
      };

      Vector3 origin  = transform.position;
      Vector3 prevDot = origin;


      Gizmos.color = Color.yellow;
      Gizmos.DrawLine(origin + moveVector * SCALE, origin + (moveVector + Vector3.right * (DELTA * ITER)) * SCALE);
      Gizmos.color = Color.green;

      smoothClone.Init(origin);

      for (var i = 0; i < ITER; i++) {
        Vector3 curDot = smoothClone.Update(DELTA, origin + moveVector * SCALE);
        curDot += Vector3.right * DELTA * i * SCALE;
        Gizmos.DrawLine(prevDot, curDot);
        prevDot = curDot;
      }
    }
  }
}