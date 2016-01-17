using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    void OnCollisionEnter(Collision col) {
        GameObject hit = (GameObject)col.gameObject;
        Combat hitObj = hit.GetComponent<Combat>();
       if (!hitObj)
       {
            hitObj.TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
