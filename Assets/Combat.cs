using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Combat : NetworkBehaviour {
    public const int MaxHealth = 100;
    public bool destroyOnDeath;
    [SyncVar]
    public int health = MaxHealth;

    public void TakeDamage(int amt) {
        if (!isServer) {
            return;
        }
        health -= amt;
        if (health <= 0) {

            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else {
                health = 0;
                RpcRespawn();            
            }
        }
    }
    [ClientRpc]
    void RpcRespawn() {
        if (isLocalPlayer) {
            transform.position = Vector3.zero;
        }
    }
}
