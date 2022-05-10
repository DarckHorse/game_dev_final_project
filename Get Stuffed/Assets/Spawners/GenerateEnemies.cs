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

    public void Dec()
    {
        enemyCount = 9;
    }

    void Start()
    {
        //StartCoroutine(EnemyDrop());
        mesh_rend = gameObject.GetComponent<MeshRenderer>();
        extents = mesh_rend.bounds.extents;
        center = mesh_rend.bounds.center;
    }



    /*IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(center.x - extents.x  ,center.x + extents.x);
            zPos = Random.Range(center.z - extents.z ,center.z + extents.z );
            GameObject Enem = Instantiate(theEnemy,new Vector3(xPos, 1, zPos), Quaternion.identity);
            if(Enem.tag == "Bunny")
            {
                //Debug.Log("get rotated");
                Enem.transform.Rotate(-90.0f, 0.0f, Random.Range(0.0f, 360.0f), Space.Self);
            }
            yield return new WaitForSeconds(0.1f);
            enemyCount +=1;
        }
    }*/
    // Update is called once per frame
    void FixedUpdate()
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(center.x - extents.x  ,center.x + extents.x);
            zPos = Random.Range(center.z - extents.z ,center.z + extents.z );
            GameObject Enem = Instantiate(theEnemy,new Vector3(xPos, 1, zPos), Quaternion.identity);
            if(Enem.tag == "Bunny")
            {
                //Debug.Log("get rotated");
                Enem.transform.Rotate(-90.0f, 0.0f, Random.Range(0.0f, 360.0f), Space.Self);
            }
            //yield return new WaitForSeconds(0.1f);
            enemyCount +=1;
        }
    }
}
