using System;
using UnityEngine;

namespace UnityRef {
  [Serializable]
  public struct EcsTransform {
    public Vector3    position;
    public Quaternion rotation;
    public Vector3    scale;



    public static EcsTransform Zero => new(Vector3.zero, Quaternion.identity);

    public Vector3 Right       { get => rotation * Vector3.right; set => rotation = Quaternion.FromToRotation(Vector3.right, value); }
    public Vector3 Up          { get => rotation * Vector3.up;    set => rotation = Quaternion.FromToRotation(Vector3.up,    value); }
    public Vector3 EulerAngles { get => rotation.eulerAngles;     set => rotation = Quaternion.Euler(value); }

    public Matrix4x4 Matrix => Matrix4x4.TRS(position, rotation, scale);



    public EcsTransform(Vector3 position, Quaternion rotation = default, Vector3 scale = default) {
      this.position = position;
      this.rotation = rotation;
      this.scale    = scale == default ? Vector3.one : Vector3.zero;
    }

    public EcsTransform(Transform transform) : this(
      transform.localPosition,
      transform.localRotation,
      transform.localScale
    ) { }
  }
}