using UnityEngine;
using System.Collections;

public class ClickNav : MonoBehaviour {
    NavMeshAgent navAgent;
	// Use this for initialization
	void Start () {
        try
        {
            navAgent = (NavMeshAgent)this.GetComponent<NavMeshAgent>();
        }
        catch {
            throw new MissingReferenceException();
        }
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                navAgent.SetDestination(hit.point);
                DebugHit(hit);
                Debug.Log("Hit");
            }
            else {
                Debug.Log("No hit.");
            }
        }
	}

    void DebugHit(RaycastHit hit) {
        Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), hit.point);
    }
}
