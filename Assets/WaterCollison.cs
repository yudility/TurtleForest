using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask: MonoBehaviour
{
    public GameObject water;
    public int count;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            this.count = 3;
        }
    }

    void Update()
    {


    }
  
    public void UseFlask()
    {

    }
}
