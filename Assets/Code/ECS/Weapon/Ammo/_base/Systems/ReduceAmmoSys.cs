using Extensions.Ecs;
using Features.Weapon.Attack;
using Leopotam.EcsLite;

namespace Features.Weapon.Ammo._base {
  public class ReduceAmmoSys : IEcsRunSystem, IEcsInitSystem {
    private EcsWorld  _world;
    private EcsFilter _filter;

    private EcsPool<Magazine>    _magazinePool;
    private EcsPool<Ammo>        _ammoPool;
    private EcsPool<IsAttacking> _isAttackingPool;
    private EcsPool<BlockAttack> _blockAttackPool;

    public void Init(IEcsSystems systems) {
      _world = systems.GetWorld();
      _filter = _world.Filter<WeaponTag>()
                      .Inc<Magazine>()
                      .Exc<BlockAttack>()
                      .End();

      _magazinePool    = _world.GetPool<Magazine>();
      _blockAttackPool = _world.GetPool<BlockAttack>();
      _ammoPool        = _world.GetPool<Ammo>();
      _isAttackingPool = _world.GetPool<IsAttacking>();
    }



    public void Run(IEcsSystems systems) {
      foreach (int e in _filter) {
        ref Magazine magazine = ref _magazinePool.Get(e);

        if (magazine.IsEmpty()) {
          BlockAttack(e);
          continue;
        }

        if (Attacking(e)) {
          ReduceAmmo(e, magazine);
          continue;
        }

        UnblockAttack(e);
      }
    }



    private void ReduceAmmo(int e, Magazine magazine) {
      if (_ammoPool.Has(e))
        _ammoPool.Get(e).amount--;

      magazine.amount--;
    }

    private void BlockAttack(int   e) => _blockAttackPool.TryAdd(e);
    private void UnblockAttack(int e) => _blockAttackPool.TryDel(e);
    private bool Attacking(int     e) => _isAttackingPool.Has(e);
  }
}