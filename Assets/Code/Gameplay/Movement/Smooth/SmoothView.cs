using UnityEngine;

namespace Gameplay.Movement.Smooth {
   public class SmoothView : MonoBehaviour {
      public Transform     target;
      public SmoothVector3 value;



      private void Awake()  => value.Init(target.position);
      private void Update() => transform.position = value.Update(Time.deltaTime, target.position);
   }
}