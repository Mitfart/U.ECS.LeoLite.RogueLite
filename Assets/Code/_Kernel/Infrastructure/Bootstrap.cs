using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure {
   [RequireComponent(typeof(LifetimeScope))]
   public class Bootstrap : MonoBehaviour {
      public LifetimeScope scope;

      public void Awake() {
         scope.Build();

         scope
           .Container
           .Resolve<IGameStateMachine>()
           .Enter<BootstrapState>();

         DontDestroyOnLoad(gameObject);
      }
   }
}