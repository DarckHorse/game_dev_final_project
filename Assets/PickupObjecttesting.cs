using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjecttesting : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            print ("Item Picked up");
            Destroy (gameObject);
        }
    }
}
