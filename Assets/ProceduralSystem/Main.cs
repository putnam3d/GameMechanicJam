using UnityEngine;
using System.Collections;

namespace ProceduralSystem
{
    public class Main : MonoBehaviour
    {
        public GameObject TrueTile;
        public GameObject FalseTile;
        MapGenerator mapGen;
        public int spacing = 10;
        public float falseHeightAmt = 1;
        public int mapWidth = 10;
        public int mapHeight = 10;
        public int simSteps = 5;
        public int birthLimit = 2;
        public int deathLimit = 4;
        // Use this for initialization
        void Start()
        {
            mapGen = new MapGenerator(mapWidth, mapHeight, simSteps, birthLimit, deathLimit);
            if (mapGen._map != null)
            {
                DisplayMap();
            }
        }
        void DisplayMap() {
            
            //delete current tiles
            GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
            if (tiles.GetLength(0) > 0)
            {
                foreach (GameObject t in tiles)
                {
                    GameObject.Destroy(t);
                }
            }

            for (int x = 0; x < mapWidth; x++) {
                for (int y = 0; y < mapHeight; y++) {
                    if (mapGen._map[x, y] == true || x == 0 || x >= mapWidth - 1 || y == 0 || y >= mapHeight - 1) 
                    {
                        GameObject tile = (GameObject)Instantiate(TrueTile, new Vector3(x * spacing, 0, y * spacing), Quaternion.identity);
                        tile.transform.parent = GameObject.FindGameObjectWithTag("parent").transform;
                    }
                    else if(mapGen._map[x,y] == false){
                        GameObject tile = (GameObject)Instantiate(FalseTile, new Vector3(x * spacing, falseHeightAmt, y * spacing), Quaternion.identity);
                        tile.transform.parent = GameObject.FindGameObjectWithTag("parent").transform;
                    }
                }
            }
        }
        // Update is called once per frame
        void Update()
        {
            //Iterate simulation
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                mapGen.IterateMap();
                DisplayMap();

            }
        }
    }
}
