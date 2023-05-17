using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatragunaPlacer : MonoBehaviour
{
    public GameObject prefab;
    public Terrain terrain;
    public float yOffset = 0.5f;
    public float minHeight;
    public float maxHeight;

    public int count;

    private float terrainWidth;
    private float terrainLength;

    private float xTerrainPos;
    private float zTerrainPos;


    void Start()
    {
        //Get terrain size
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

        //Get terrain position
        xTerrainPos = terrain.transform.position.x;
        zTerrainPos = terrain.transform.position.z;

        for (int i = 0; i < count; i++)
        {
            generateObjectOnTerrain();
        }
        
    }

    void generateObjectOnTerrain()
    {
        //Generate random x,z,y position on the terrain
        float randX = UnityEngine.Random.Range(xTerrainPos, xTerrainPos + terrainWidth);
        float randZ = UnityEngine.Random.Range(zTerrainPos, zTerrainPos + terrainLength);
        float yVal = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));

        if(!(yVal > maxHeight || yVal < minHeight))
        {
            //Apply Offset if needed
            yVal = yVal + yOffset;

            //Generate the Prefab on the generated position
            GameObject objInstance = (GameObject)Instantiate(prefab, new Vector3(randX, yVal, randZ), Quaternion.identity);
        }

        
    }
}
