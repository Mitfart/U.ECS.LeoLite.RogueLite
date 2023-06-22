using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using UnityEngine;
using VContainer;

namespace Infrastructure {
  [DefaultExecutionOrder(-1)]
  [RequireComponent(typeof(GameScope))]
  public class Bootstrap : MonoBehaviour {
    private IGameStateMachine _gameStateMachine;



    [Inject]
    private void Construct(IGameStateMachine gameStateMachine) {
      _gameStateMachine = gameStateMachine;
    }

    private void Awake() => DontDestroyOnLoad(this);
    private void Start() => _gameStateMachine.Enter<BootstrapState>();
  }
}