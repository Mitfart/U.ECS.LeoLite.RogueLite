using System;
using Extensions.Ecs;
using Extensions.Unileo;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.UnityRef {
   [Serializable]
   public struct EcsTransform {
      [SerializeField] private Vector3    localPosition;
      [SerializeField] private Quaternion localRotation;
      [SerializeField] private float      localScale;

      [SerializeField] private Vector3    position;
      [SerializeField] private Quaternion rotation;
      [SerializeField] private float      scale;



      private EcsPackedEntityWithWorld? _parentE;



      public EcsTransform(Vector3 localPos = default, Quaternion? localRot = null, float scale = 1f, EcsPackedEntityWithWorld? parentE = null) {
         localPosition = localPos;
         localRotation = localRot ?? Quaternion.identity;
         localScale    = scale;
         _parentE      = parentE;

         position   = default;
         rotation   = default;
         this.scale = default;

         Refresh();
      }

      public EcsTransform(Transform transform) : this(transform.localPosition, transform.localRotation, transform.localScale.x, transform.ParentEntity()) { }

      public EcsTransform? Parent => ParentE?.GetOrNull<EcsTransform>();

      public EcsPackedEntityWithWorld? ParentE {
         get => _parentE;
         set {
            _parentE = value;
            Refresh();
         }
      }



      public Vector3 Position {
         get => position;
         set => ReCalcLocalPosition(position = value);
      }

      public Quaternion Rotation {
         get => rotation;
         set => ReCalcLocalRotation(rotation = value);
      }

      public float Scale {
         get => scale;
         set => ReCalcLocalScale(scale = value);
      }

      public Vector3 LocalPosition {
         get => localPosition;
         set => ReCalcPosition(localPosition = value);
      }

      public Quaternion LocalRotation {
         get => localRotation;
         set => ReCalcRotation(localRotation = value);
      }

      public float LocalScale {
         get => localScale;
         set => ReCalcScale(localScale = value);
      }



      public EcsTransform Refresh() {
         ReCalcPosition();
         ReCalcRotation();
         ReCalcScale();
         return this;
      }

      private Vector3 ReCalcPosition(Vector3? newLocalPos = null) {
         return position = ParentRot() * (newLocalPos ?? localPosition) + ParentPos();
      }

      private Quaternion ReCalcRotation(Quaternion? newLocalRot = null) {
         return rotation = ParentRot() * (newLocalRot ?? localRotation);
      }

      private float ReCalcScale(float? newLocalScale = null) {
         return scale = ParentScale() * (newLocalScale ?? localScale);
      }

      private Vector3 ReCalcLocalPosition(Vector3? newPos = null) {
         return localPosition = Quaternion.Inverse(ParentRot()) * (newPos ?? position) - ParentPos();
      }

      private Quaternion ReCalcLocalRotation(Quaternion? newRot = null) {
         return localRotation = Quaternion.Inverse(ParentRot()) * (newRot ?? rotation);
      }

      private float ReCalcLocalScale(float? newScale = null) {
         return localScale = (newScale ?? scale) / ParentScale();
      }

      private Vector3 ParentPos() {
         return Parent?.Position ?? Vector3.zero;
      }

      private Quaternion ParentRot() {
         return Parent?.Rotation ?? Quaternion.identity;
      }

      private float ParentScale() {
         return Parent?.Scale ?? 1f;
      }
   }
}