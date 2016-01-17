using UnityEngine;
using System.Collections;

public class MoveCom : AbstractCommand{
    public MoveCom() {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public override void Use(Vector3 mPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f)) {
            NavMeshAgent navAgent = (NavMeshAgent)GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
            navAgent.SetDestination(hit.point);
            Debug.Log("Move Command Used.");
        }
        
    }
}
