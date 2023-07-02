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
         DontDestroyOnLoad(gameObject);
         scope.Build();
         EnterBootState();
      }

      private void              EnterBootState()   => GameStateMachine().Enter<BootstrapState>();
      private IGameStateMachine GameStateMachine() => scope.Container.Resolve<IGameStateMachine>();
   }
}