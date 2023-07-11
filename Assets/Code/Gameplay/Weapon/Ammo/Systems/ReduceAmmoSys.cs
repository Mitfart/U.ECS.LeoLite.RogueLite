using Extensions.Ecs;
using Gameplay.Weapon.Ammo.Comps;
using Gameplay.Weapon.Attack.Comps;
using Leopotam.EcsLite;

namespace Gameplay.Weapon.Ammo.Systems {
   public class ReduceAmmoSys : IEcsRunSystem, IEcsInitSystem {
      private EcsWorld  _world;
      private EcsFilter _filter;

      private EcsPool<Magazine>    _magazinePool;
      private EcsPool<IsAttacking> _isAttackingPool;
      private EcsPool<BlockAttack> _blockAttackPool;

      
      
      public void Init(IEcsSystems systems) {
         _world  = systems.GetWorld();
         _filter = _world.Filter<_base.Weapon>().Inc<Magazine>().Exc<BlockAttack>().End();

         _magazinePool    = _world.GetPool<Magazine>();
         _blockAttackPool = _world.GetPool<BlockAttack>();
         _isAttackingPool = _world.GetPool<IsAttacking>();
      }
      
      public void Run(IEcsSystems systems) {
         foreach (int e in _filter) {
            if (Magazine(e).IsEmpty()) {
               BlockAttack(e);
               continue;
            }

            if (Attacking(e)) {
               ReduceAmmo(e);
               continue;
            }

            UnblockAttack(e);
         }
      }



      private     void     ReduceAmmo(int e) => Magazine(e).amount--;

      private ref Magazine Magazine(int      e) => ref _magazinePool.Get(e);
      private     void     BlockAttack(int   e) => _blockAttackPool.TryAdd(e);
      private     void     UnblockAttack(int e) => _blockAttackPool.TryDel(e);
      private     bool     Attacking(int     e) => _isAttackingPool.Has(e);
   }
}