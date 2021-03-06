﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class EnemySpawner : NetworkBehaviour {
    
    public GameObject enemyPrefab;
    public int numEnemies;
    public override void OnStartServer()
    {
        for (int i = 0; i < numEnemies; i++) {
            Vector3 pos = new Vector3(Random.Range(-8.0f, 8.0f), 0.2f, Random.Range(-8.0f, 8.0f));
            Quaternion rotation = Quaternion.Euler(Random.Range(0,180), Random.Range(0,180), Random.Range(0,180));
            GameObject enemy = (GameObject)GameObject.Instantiate(enemyPrefab, pos, rotation);
            NetworkServer.Spawn(enemy);
        }
    }
}
