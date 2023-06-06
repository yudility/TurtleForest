using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player의 위치 랜덤 지정 - 기본 아이템(손전등 등) 옆에 같이 띄워줌
public class InstantiatePlayer : MonoBehaviour
{
    public GameObject prefab;
    public Terrain terrain;
    public float yOffset = 0.2f;
    public GameObject Basic;

    private float terrainWidth;
    private float terrainLength;

    private float xTerrainPos;
    private float zTerrainPos;
    //public int count = 0;


    void Start()
    {
        //Get terrain size
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

        //Get terrain position
        xTerrainPos = terrain.transform.position.x;
        zTerrainPos = terrain.transform.position.z;

        generateObjectOnTerrain();
    }

    void generateObjectOnTerrain()
    {

        //Generate random x,z,y position on the terrain
        float randX = UnityEngine.Random.Range(xTerrainPos, xTerrainPos + terrainWidth);
        float randZ = UnityEngine.Random.Range(zTerrainPos, zTerrainPos + terrainLength);
        float yVal = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));

            //Apply Offset if needed
        yVal = yVal + yOffset;

        //Generate the Prefab on the generated position
        //GameObject objInstance = (GameObject)Instantiate(prefab, new Vector3(randX, yVal, randZ), Quaternion.identity);
        //terrain 끝 부분에서 떨어짐 방지
        transform.position = new Vector3(randX - 1.0f, yVal, randZ - 1.0f);
        Basic.transform.position = new Vector3(randX - 1.5f, yVal + 1.0f, randZ - 1.5f);

    }

    void Update()
    {

    }
}
