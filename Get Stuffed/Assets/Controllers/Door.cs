using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    string next_loc;
    Vector3 start_pos;

    // Start is called before the first frame update
    void Start()
    {
        next_loc = gameObject.name;
        if (SceneManager.GetActiveScene().name != "Hallway"){
            if (SceneManager.GetActiveScene().name == "Bedroom") {
                start_pos = new Vector3();
            }
            else if (SceneManager.GetActiveScene().name == "Bathroom") {
                start_pos = new Vector3();
            }
            else if (SceneManager.GetActiveScene().name == "Kitchen") {
                start_pos = new Vector3();
            }
            else if (SceneManager.GetActiveScene().name == "Attic") {
                start_pos = new Vector3();
            }
        }
        else{
            start_pos = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetType() == typeof(MeshCollider) && collider.tag == "Player") {
            collider.gameObject.transform.position = start_pos;
            SceneManager.LoadScene(next_loc);
            }
    }

}
