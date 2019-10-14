using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawn : MonoBehaviour
{

    public GameObject player;
    public Transform[] spawnPositions;

    public void startGame()
    {
        spawnplayer();
    }

    private void spawnplayer()
    {
        int SpawnIndex = Random.Range(0, spawnPositions.Length);
        Instantiate(player, spawnPositions[SpawnIndex].position, Quaternion.identity);
    }
}
