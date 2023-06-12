using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomizer : MonoBehaviour
{
    public GameObject plane;
    public Vector3 spawnAreaSize;

    void Start()
    {
        RandomizeObjectPositions();
    }

    void RandomizeObjectPositions()
    {
        Renderer planeRenderer = plane.GetComponent<Renderer>();
        Vector3 planeSize = planeRenderer.bounds.size;

        foreach (Transform child in plane.transform)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(plane.transform.position.x - spawnAreaSize.x / 2f, plane.transform.position.x + spawnAreaSize.x / 2f),
                plane.transform.position.y,
                Random.Range(plane.transform.position.z - spawnAreaSize.z / 2f, plane.transform.position.z + spawnAreaSize.z / 2f)
            );

            child.position = randomPosition;
        }
    }
}
