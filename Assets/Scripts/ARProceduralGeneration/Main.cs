using UnityEngine;
using System.Collections;
using ProceduralSystem;

namespace Scripts.ARProceduralGeneration
{
    public class Main : MonoBehaviour
    {
        public GameObject imgTarget;
        MapGenerator mpGen;

        // Use this for initialization
        void Start()
        {
            imgTarget = GameObject.FindGameObjectWithTag("ImgTarget");
            //mpGen = new MapGenerator();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
