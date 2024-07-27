using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : NetworkBehaviour, IPlayerJoined, IPlayerLeft
{
    [SerializeField] private NetworkPrefabRef playerNetworkPrefab = NetworkPrefabRef.Empty;
    [SerializeField] private Transform[] spawnPoints;

    public override void Spawned()
    {
        base.Spawned();

        if(Runner.IsServer)
        {
            foreach(var item in Runner.ActivePlayers)
            {
                SpawnPlayer(item);
            }
        }
    }

    private void SpawnPlayer(PlayerRef playerRef)
    {
        if(Runner.IsServer)
        {
            var index = playerRef % spawnPoints.Length;
            var playerSpawnPoint = spawnPoints[index].transform.position;
            var playerObject = Runner.Spawn(playerNetworkPrefab, playerSpawnPoint, Quaternion.identity, playerRef);
            Runner.SetPlayerObject(playerRef, playerObject); // this will set this player a local player object
        }
    }
    private void DespawnPlayer(PlayerRef playerRef) // remove player if other player left the room
    {
        if(Runner.IsServer)
        {
            if(Runner.TryGetPlayerObject(playerRef, out var playerNetworkObject))
            {
                Runner.Despawn(playerNetworkObject);
            }

            Runner.SetPlayerObject(playerRef, null); //reset player object
        }
    }

    public void PlayerJoined(PlayerRef player)
    {
        SpawnPlayer(player);
    }


    public void PlayerLeft(PlayerRef player)
    {
        DespawnPlayer(player);
    }
}
