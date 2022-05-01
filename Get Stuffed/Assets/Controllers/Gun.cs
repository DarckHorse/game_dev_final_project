using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotates gun up/down
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0));
    }
}
