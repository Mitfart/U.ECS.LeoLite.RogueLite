using Leopotam.EcsLite;

namespace Battle.UI {
  public class SetHealthUISys : IEcsRunSystem, IEcsInitSystem {
    private EcsFilter _filter;

    private EcsPool<HealthBar> _healthBarPool;
    private EcsPool<Health>    _healthPool;
    private EcsWorld           _world;

    public void Init(IEcsSystems systems) {
      _world  = systems.GetWorld();
      _filter = _world.Filter<HealthBar>().Inc<Health>().End();

      _healthBarPool = _world.GetPool<HealthBar>();
      _healthPool    = _world.GetPool<Health>();
    }

    public void Run(IEcsSystems systems) {
      foreach (int e in _filter) {
        ref HealthBar healthBar = ref _healthBarPool.Get(e);
        ref Health    health    = ref _healthPool.Get(e);

        healthBar.Bar.value = health.cur / health.max;
      }
    }
  }
}