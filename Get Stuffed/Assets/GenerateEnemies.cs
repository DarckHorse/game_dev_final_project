using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public float xPos;
    public float zPos;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }



    IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(-1.4f,6.7f);
            zPos = Random.Range(-4.4f, 4.4f);
            Instantiate(theEnemy,new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount +=1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
