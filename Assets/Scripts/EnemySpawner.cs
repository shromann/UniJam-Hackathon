using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float maxHeight = 2;
    public float minHeight = 1;

    public int maxTime = 2;
    public int minTime = 1;

    public GameObject enemyType;

    private float timer = 0;
    private int spawnTime;

    // https://answers.unity.com/questions/898380/spawning-an-object-at-a-random-time-c.html
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        //int spawnTime = Random.Range(minTime, maxTime);

        if (timer >= spawnTime)
        {
            float enemyHeight = Random.Range(minHeight, maxHeight);
            Instantiate(enemyType, new Vector3(transform.position.x, enemyHeight, transform.position.z), Quaternion.identity);

            spawnTime = Random.Range(minTime, maxTime);
            timer = 0;
        }

        timer += Time.deltaTime;
        //Debug.Log((int)timer % 60);
    }
}
