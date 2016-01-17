using UnityEngine;
using System.Collections;

abstract public class AbstractCommand : MonoBehaviour {
    abstract public void Use(Vector3 vec);
}
