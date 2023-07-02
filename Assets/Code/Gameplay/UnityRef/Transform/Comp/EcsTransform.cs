using System;
using Extensions.Ecs;
using Extensions.Unileo;
using Leopotam.EcsLite;
using UnityEngine;

namespace UnityRef {
   [Serializable]
   public struct EcsTransform {
      [SerializeField] private Vector3    localPosition;
      [SerializeField] private Quaternion localRotation;
      [SerializeField] private float      localScale;

      [SerializeField] private Vector3    position;
      [SerializeField] private Quaternion rotation;
      [SerializeField] private float      scale;
      
      private EcsPackedEntityWithWorld? _parentE;

      

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

      private Vector3    ReCalcPosition(Vector3?    newLocalPos   = null) => position = ParentRot() * (newLocalPos ?? localPosition) + ParentPos();
      private Quaternion ReCalcRotation(Quaternion? newLocalRot   = null) => rotation = ParentRot() * (newLocalRot   ?? localRotation);
      private float      ReCalcScale(float?         newLocalScale = null) => scale = ParentScale()  * (newLocalScale ?? localScale);

      private Vector3    ReCalcLocalPosition(Vector3?    newPos   = null) => localPosition = Quaternion.Inverse(ParentRot()) * (newPos ?? position) - ParentPos();
      private Quaternion ReCalcLocalRotation(Quaternion? newRot   = null) => localRotation = Quaternion.Inverse(ParentRot()) * (newRot ?? rotation);
      private float      ReCalcLocalScale(float?         newScale = null) => localScale = (newScale                                    ?? scale) / ParentScale();

      private Vector3    ParentPos()   => Parent?.Position ?? Vector3.zero;
      private Quaternion ParentRot()   => Parent?.Rotation ?? Quaternion.identity;
      private float      ParentScale() => Parent?.Scale    ?? 1f;
   }
}