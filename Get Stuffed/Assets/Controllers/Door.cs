using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    string next_loc;
    public Vector3 start_pos;

    // Start is called before the first frame update
    void Start()
    {
        next_loc = gameObject.name;
        if (SceneManager.GetActiveScene().name != "hallway"){
            if (SceneManager.GetActiveScene().name == "bedroom") {
                // start_pos = new Vector3();
            }
            else if (SceneManager.GetActiveScene().name == "bathroom") {
                // start_pos = new Vector3();
            }
            else if (SceneManager.GetActiveScene().name == "kitchen") {
                // start_pos = new Vector3();
            }
            else if (SceneManager.GetActiveScene().name == "attic") {
                // start_pos = new Vector3();
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
        // collider.GetType() == typeof(MeshCollider) && 
        if (collider.tag == "Player") {
            Debug.Log("Hey");
            SceneManager.LoadScene(next_loc);
            transform.position = collider.gameObject.GetComponent<Door>().start_pos;
            // SceneManager.LoadScene(next_loc);
        }
    }

}
