using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab; // 생성할 물체의 프리팹
    private bool hasSpawned = false;

    private void Start()
    {
        if (!hasSpawned)
        {
            SpawnObject();
            hasSpawned = true;
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = transform.position + transform.forward * 1.0f; // 특정 오브젝트로부터 1.0f 떨어진 위치 계산
        Instantiate(prefab, spawnPosition, Quaternion.identity); // 물체 생성
    }
}
