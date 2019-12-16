using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int SpawnTime;
    public GameObject TopLeftBorder;
    public GameObject BottomRightBorder;
    public GameObject Enemy;

    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //WTF IS THIS SHIT
        timer++;

        if(timer == SpawnTime)
        {
            timer = 0;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int rand = Random.Range(1, 3);

        if (rand == 1)
        {
            Instantiate(Enemy, new Vector2(TopLeftBorder.transform.position.x, Random.Range(TopLeftBorder.transform.position.y, BottomRightBorder.transform.position.y)), Quaternion.identity);
        }
        else
        {
            Instantiate(Enemy, new Vector2(BottomRightBorder.transform.position.x, Random.Range(TopLeftBorder.transform.position.y, BottomRightBorder.transform.position.y)), Quaternion.identity);
        }
    }
}
