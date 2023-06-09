﻿using Leopotam.EcsLite;
using VContainer;

namespace Gameplay.Unit.Behavior.Tree.Nodes {
   public abstract class BehaviorNode {
      protected IObjectResolver Di;

      protected int            Entity;
      protected EcsWorld       World;
      public    bool           IsActive   { get; private set; }
      public    BehaviorState  CurState   { get; private set; } = BehaviorState.Run;
      protected BehaviorNode[] ChildNodes { get; }



      protected BehaviorNode(params BehaviorNode[] childNodes) {
         ChildNodes = childNodes;
      }

      public void Init(int entity, EcsWorld world, IObjectResolver di) {
         Di = di;

         Entity = entity;
         World  = world;

         foreach (BehaviorNode childNode in ChildNodes) {
            childNode.Init(Entity, World, di);
         }

         OnInit();
      }



      public BehaviorState Run() {
         if (!IsActive)
            Begin();

         CurState = OnRun();

         if (CurState != BehaviorState.Run)
            Finish();

         return CurState;
      }

      private void Begin() {
         IsActive = true;
         OnBegin();
      }

      private void Finish() {
         IsActive = false;
         OnFinish();
      }


      protected virtual BehaviorState OnRun() {
         BehaviorState finalState = BehaviorState.Success;

         foreach (BehaviorNode node in ChildNodes) {
            BehaviorState childState = node.Run();

            if (childState == BehaviorState.Run)
               finalState = BehaviorState.Run;
         }

         return finalState;
      }


      protected virtual void OnInit()   { }
      protected virtual void OnBegin()  { }
      protected virtual void OnFinish() { }
   }
}