using System;
using Extensions;
using Extensions.Ecs;
using Extensions.Unileo;
using Extentions;
using Leopotam.EcsLite;
using UnityEngine;

[Serializable]
public struct EcsTransform {
  [SerializeField] private Vector3    localPosition;
  [SerializeField] private Quaternion localRotation;
  [SerializeField] private float      localScale;

  [SerializeField] private Vector3    position;
  [SerializeField] private Quaternion rotation;
  [SerializeField] private float      scale;

  private EcsPackedEntityWithWorld _parentE;



  public EcsTransform Parent => ParentE.GetOrDefault<EcsTransform>();

  public EcsPackedEntityWithWorld ParentE {
    get => _parentE;
    set {
      _parentE = value;
      ReCalcGlobal();
    }
  }



  public Vector3    Position { get => position; set => ReCalcLocalPosition(position = value); }
  public Quaternion Rotation { get => rotation; set => ReCalcLocalRotation(rotation = value); }
  public float      Scale    { get => scale;    set => ReCalcLocalScale(scale = value); }

  public Vector3    LocalPosition { get => localPosition; set => ReCalcPosition(localPosition = value); }
  public Quaternion LocalRotation { get => localRotation; set => ReCalcRotation(localRotation = value); }
  public float      LocalScale    { get => localScale;    set => ReCalcScale(localScale = value); }


  public Matrix4x4 Matrix => Matrix4x4.TRS(Position, Rotation, Vector3.one * Scale);



  public EcsTransform(
    Vector3?                  position = null,
    Quaternion?               rotation = null,
    float                     scale    = 1f,
    EcsPackedEntityWithWorld? parentE  = null
  ) {
    localPosition = position ?? Vector3.zero;
    localRotation = rotation ?? Quaternion.identity;
    localScale    = scale;

    this.position = localPosition;
    this.rotation = localRotation;
    this.scale    = localScale;

    _parentE = parentE ?? default;

    ReCalcGlobal();
  }

  public EcsTransform(Transform transform) : this(
    transform.position,
    transform.rotation,
    transform.lossyScale.x,
    transform.EntityParent().PackedEntityWWOrDefault()
  ) { }



  private void ReCalcGlobal() {
    ReCalcPosition();
    ReCalcRotation();
    ReCalcScale();
  }

  private Vector3    ReCalcPosition(Vector3?    newLocalPos   = null) => position = Parent.Rotation * (newLocalPos ?? localPosition) + Parent.Position;
  private Quaternion ReCalcRotation(Quaternion? newLocalRot   = null) => rotation = Parent.Rotation * (newLocalRot   ?? localRotation);
  private float      ReCalcScale(float?         newLocalScale = null) => scale = Parent.Scale       * (newLocalScale ?? localScale);

  private Vector3    ReCalcLocalPosition(Vector3?    newPos   = null) => localPosition = Quaternion.Inverse(Parent.Rotation) * (newPos ?? Position) - Parent.Position;
  private Quaternion ReCalcLocalRotation(Quaternion? newRot   = null) => localRotation = Quaternion.Inverse(Parent.Rotation) * (newRot ?? Rotation);
  private float      ReCalcLocalScale(float?         newScale = null) => localScale = (newScale                                        ?? Scale) / Parent.Scale;
}