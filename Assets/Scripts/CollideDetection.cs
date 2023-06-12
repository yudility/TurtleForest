using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDetection : MonoBehaviour
{

    private GameObject collidedObject;
    public GameObject ExitObject;

    void Start()
    {
        GameManager mg = GameManager.GetInstance();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Collision Tag: " + collision.gameObject.tag);
        //Debug.Log("Collision Name: " + collision.gameObject.name);
        collidedObject = collision.gameObject;
        Debug.Log("collidedObject : " + collidedObject.name);

        if (collision.CompareTag("Player"))
        {
            //collidedObject = collision.gameObject;
            GameManager.GetInstance().ShowGameOverUI(ExitObject);
            Debug.Log("collision Exit");
        }          
    }
}
