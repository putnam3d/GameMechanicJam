using UnityEngine;
using System.Collections;

public class AttackCom : AbstractCommand {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Use(Vector3 mPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mPos);
        RaycastHit hit;
        int enMask = 1 << 9;
        if (Physics.Raycast(ray, out hit, 1000f, enMask))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.LookAt(hit.point, Vector3.up);

            Debug.Log("Attack Command Used.");
        }
    }
}
