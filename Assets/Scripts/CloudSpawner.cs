using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float maxHeight = 6.5f;
    public float minHeight = 5f;

    public float maxTime = 1f;
    public float minTime = 0.5f;

    public GameObject[] clouds;

    private float timer = 0;
    private float spawnTime;

    // https://answers.unity.com/questions/898380/spawning-an-object-at-a-random-time-c.html
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    
    void Update()
    {
        //int spawnTime = Random.Range(minTime, maxTime);

        if (timer >= spawnTime)
        {
            int cloudType = Random.Range(0, clouds.Length);

            float spawnHeight = Random.Range(minHeight, maxHeight);

            Instantiate(clouds[cloudType], new Vector3(transform.position.x, spawnHeight, transform.position.z), Quaternion.identity);

            spawnTime = Random.Range(minTime, maxTime);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
