using System.Collections.Generic;
using Infrastructure.AssetsManagement;
using Unity.Mathematics;
using UnityEngine;

namespace Infrastructure.Factories {
   public class PlayerFactory : Factory {
      private const string _CONTAINER_NAME = "Players";

      private readonly List<GameObject> _players;



      public PlayerFactory(IAssets assets) : base(assets) {
         _players = new List<GameObject>();
      }

      public override void Reset() {
         base.Reset();

         _players.Clear();
      }



      public GameObject Spawn(Vector3 at) {
         GameObject playerIns = Assets.Ins<GameObject>(
            AssetPath.PLAYER,
            at,
            quaternion.identity,
            Container(_CONTAINER_NAME)
         );
         Cache(playerIns);
         return playerIns;
      }



      private void Cache(GameObject playerIns) => _players.Add(playerIns);
   }
}