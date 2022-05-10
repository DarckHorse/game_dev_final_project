using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public float xPos;
    public float zPos;
    public int enemyCount;
    MeshRenderer mesh_rend;
    Vector3 center;
    Vector3 extents;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
        mesh_rend = GameObject.Find(SceneManager.GetActiveScene().name).GetComponent<MeshRenderer>();
        extents = mesh_rend.bounds.extents;
        center = mesh_rend.bounds.center;
    }



    IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(center.x - extents.x,center.x + extents.x);
            zPos = Random.Range(center.z - extents.z,center.z + extents.z);
            Instantiate(theEnemy,new Vector3(xPos, 50, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount +=1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
