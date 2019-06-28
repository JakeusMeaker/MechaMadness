using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildCity : MonoBehaviour {

    public GameObject[] buildings;
    public GameObject xStreets;
    public GameObject zStreets;
    public GameObject crossRoad;
    public int mapWidth = 20;
    public int mapHeight = 20;
    int[,] mapgrid;
    int buildingFootprint = 20;


    void Start ()
    {
        mapgrid = new int[mapWidth, mapHeight];

        float seed = Random.Range(0, 100);

        //Generate map data
        for(int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                mapgrid[w,h] = (int)(Mathf.PerlinNoise(w/ 20.0f + seed, h/ 20.0f + seed) * 10);
            }
        }

        //Build Streets
        int x = 0;
        for(int n = 0; n < 50; n++)
        {
            for(int h = 0; h < mapHeight; h++)
            {
                mapgrid[x, h] = -1;
            }
            x += Random.Range(2, 4);
            if (x >= mapWidth) break;
        }

        int z = 0;
        for (int n = 0; n < 10; n++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                if (mapgrid[w, z] == -1) // put crossroad
                    mapgrid[w, z] = -3;
                else
                    mapgrid[w, z] = -2;
            }
            z += Random.Range(5, 20);
            if (z >= mapHeight) break;
        }

        //Generate city
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                int result = mapgrid[w, h];
                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);

                if (result < -2)
                    Instantiate(crossRoad, pos, crossRoad.transform.rotation);
                else if (result < -1)
                    Instantiate(xStreets, pos, xStreets.transform.rotation);
                else if (result < 0)
                    Instantiate(zStreets, pos, zStreets.transform.rotation);
                else if (result < 2)
                    Instantiate(buildings[0], pos, Quaternion.identity);
                else if (result < 4)
                    Instantiate(buildings[1], pos, Quaternion.identity);
                else if (result < 5)
                    Instantiate(buildings[2], pos, Quaternion.identity);
                else if (result < 6)
                    Instantiate(buildings[3], pos, Quaternion.identity);
                else if (result < 7)
                    Instantiate(buildings[4], pos, Quaternion.identity);
                else if (result < 8)
                    Instantiate(buildings[5], pos, Quaternion.identity);
                else if (result < 9)
                    Instantiate(buildings[6], pos, Quaternion.identity);
                else if (result < 10)
                    Instantiate(buildings[7], pos, Quaternion.identity);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
