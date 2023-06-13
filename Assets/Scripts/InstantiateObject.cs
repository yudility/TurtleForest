using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아이템(버섯이나 물병 나침반 등) 랜덤 위치 생성 코드
public class InstantiateObject : MonoBehaviour
{
    public GameObject prefab;
    public Terrain terrain;
    public float yOffset = 0.1f;

    private float terrainWidth;
    private float terrainLength;

    private float xTerrainPos;
    private float zTerrainPos;
    public int count = 0;


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

        yVal = yVal + yOffset;

        //Generate the Prefab on the generated position
        //terrain 끝 부분에서 떨어짐 방지
        transform.position = new Vector3(randX - 0.5f, yVal, randZ - 0.5f);
    }

    void Update()
    {

    }
}