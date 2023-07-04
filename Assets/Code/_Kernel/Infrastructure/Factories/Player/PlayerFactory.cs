using System.Collections.Generic;
using Infrastructure.AssetsManagement;
using Mitfart.LeoECSLite.UniLeo;
using UnityEngine;

namespace Infrastructure.Factories.Extensions {
   public class PlayerFactory : Factory {
      private readonly List<ConvertToEntity> _players;



      public PlayerFactory(IAssets assets) : base(assets) {
         _players = new List<ConvertToEntity>();
      }

      public ConvertToEntity Spawn(Vector3 at) {
         var playerIns = Assets.Ins<ConvertToEntity>(AssetPath.PLAYER, at);
         _players.Add(playerIns);
         return playerIns;
      }
   }
}