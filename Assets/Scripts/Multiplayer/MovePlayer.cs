using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class MovePlayer : NetworkBehaviour {

    public GameObject bulletPrefab;

	// Update is called once per frame
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
	void Update () {

        if (!isLocalPlayer) {
            return;
        }
        float x = Input.GetAxis("Horizontal") * 0.1f;
        float z = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, 0, z);

        if (Input.GetKeyDown(KeyCode.Space)) {
            CmdFire();
        }
	}
    [Command]
    void CmdFire() {
        GameObject bullet = (GameObject)GameObject.Instantiate(bulletPrefab, transform.position - transform.forward, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = -transform.forward * 4f;

        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2f);
    }
}
