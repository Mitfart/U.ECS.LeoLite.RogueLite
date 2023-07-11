using System.Collections.Generic;
using Gameplay.Player.Adapters;
using Infrastructure.AssetsManagement;
using Leopotam.EcsLite;
using UnityEngine;

namespace Infrastructure.Factories {
   public class PlayerFactory : Factory {
      private const string _CONTAINER_NAME = "Players";

      private readonly List<PlayerAdapter> _players;

      private readonly EcsWorld _world;



      public PlayerFactory(IAssets assets, EcsWorld world) : base(assets) {
         _world   = world;
         _players = new List<PlayerAdapter>();
      }

      public override void Reset() {
         base.Reset();

         _players.Clear();
      }



      public PlayerAdapter Spawn(Vector3 at) {
         PlayerAdapter playerIns = Assets.Ins<PlayerAdapter>(
            AssetPath.PLAYER,
            at,
            Quaternion.identity,
            Container(_CONTAINER_NAME)
         );

         playerIns.Converter.Convert(_world, _world.NewEntity());

         Cache(playerIns);
         return playerIns;
      }



      private void Cache(PlayerAdapter playerIns) => _players.Add(playerIns);
   }
}