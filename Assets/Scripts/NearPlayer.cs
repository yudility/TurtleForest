using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearPlayer : MonoBehaviour
{
    public GameObject Player;
    public float SpacingZ;

    // Start is called before the first frame update
    void Start()
    {
        SpacingZ = 1.0f;

        // make the copy
        //GameObject Thisobj = Instantiate<GameObject>(Player);
        

        // move it to the original cube's position, plus "SpacingZ" distance
        // along the original cube's +Z axis orientation
        transform.position = Player.transform.position + Player.transform.forward * SpacingZ;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
