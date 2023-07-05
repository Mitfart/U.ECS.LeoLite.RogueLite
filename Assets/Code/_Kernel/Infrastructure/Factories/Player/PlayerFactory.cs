using System.Collections.Generic;
using Infrastructure.AssetsManagement;
using Mitfart.LeoECSLite.UniLeo;
using Unity.Mathematics;
using UnityEngine;

namespace Infrastructure.Factories.Extensions {
   public class PlayerFactory : Factory {
      private const string _CONTAINER_NAME = "Players";

      private readonly List<ConvertToEntity> _players;



      public PlayerFactory(IAssets assets) : base(assets) {
         _players = new List<ConvertToEntity>();
      }

      public override void Reset() {
         base.Reset();

         _players.Clear();
      }



      public ConvertToEntity Spawn(Vector3 at) {
         ConvertToEntity playerIns = Assets.Ins<ConvertToEntity>(
            AssetPath.PLAYER,
            at,
            quaternion.identity,
            Container(_CONTAINER_NAME)
         );
         Cache(playerIns);
         return playerIns;
      }



      private void Cache(ConvertToEntity playerIns) => _players.Add(playerIns);
   }
}