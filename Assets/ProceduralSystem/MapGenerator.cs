using UnityEngine;
using System.Collections;

public class MapGenerator {
    int birthLimit = 0;
    int deathLimit = 0;
    int mapWidth = 0;
    int mapHeight = 0;
    int simSteps = 0;
    bool[,] map;
    public bool[,] _map {
        get { return map; }
    }

    public MapGenerator(int mapWidth, int mapHeight, int simSteps, int birthLimit, int deathLimit) {
        this.mapWidth = mapWidth;
        this.mapHeight = mapHeight;
        this.simSteps = simSteps;
        this.birthLimit = birthLimit;
        this.deathLimit = deathLimit;
        map = new bool[mapWidth, mapHeight];
        InitalizeMap();
        GenerateMap();
    }

    void GenerateMap() {

        for (int x = 0; x < simSteps; x++)
        {
            map = SimulationStep();
        }
    }

    public void IterateMap() {
        map = SimulationStep();
    }

    void InitalizeMap() {
        //loop through each position in map
        for (int x = 0; x < mapWidth; x++) {
            for (int y = 0; y < mapHeight; y++ )
            {
                if (0.5f < Random.Range(0f, 1f))
                {
                    map[x, y] = true;
                }
                else {
                    map[x, y] = false;
                }
            }
        }
    }

    bool[,] SimulationStep() {
        int na = 0;
        bool[,] newMap = new bool[mapWidth, mapHeight];
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++) {
                na = CheckNumNeighborsAlive(x, y);
                switch (map[x, y]) {
                    case true:
                        if (na > deathLimit) {
                            newMap[x, y] = false;
                        }
                        break;
                    case false:
                        if (na < birthLimit) {
                            newMap[x, y] = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return newMap;
    }

    int CheckNumNeighborsAlive(int x , int y) {
        int numAlive = 0;
                //top left
                if (x == 0 || y == 0)
                {
                    numAlive++;
                }
                else if (map[x - 1, y - 1])
                {
                    numAlive++;
                }

                if (y == 0) {
                    numAlive++;
                }
                //top-mid
                else if(map[x, y-1]){
                    numAlive++;
                }

                if (x >= mapWidth-1 || y == 0) {
                    numAlive++;
                }
                //top-right
                else if (map[x + 1, y - 1]) {
                    numAlive++;
                }

                if (x == 0)
                {
                    numAlive++;
                }
                //mid left
                else if (map[x -1, y])
                {
                    numAlive++;
                }

                if(x >= mapWidth -1){
                    numAlive++;
                }
                //mid-right
                else if (map[x + 1, y])
                {
                    numAlive++;
                }

                if (x == 0 || y >= mapHeight -1) {
                    numAlive++;
                }
                //btm left
                else if (map[x - 1, y + 1])
                {
                    numAlive++;
                }

                if (y >= mapHeight - 1)
                {
                    numAlive++;
                }
                //btm-mid
                else if (map[x, y + 1])
                {
                    numAlive++;
                }

                if (x >= mapWidth -1 || y == mapHeight - 1) {
                    numAlive++;
                }
                //btm-right
                else if (map[x + 1, y + 1])
                {
                    numAlive++;
                }

        return numAlive;
    }
}
