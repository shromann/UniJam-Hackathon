using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject obstacle;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    // Update is called once per frame
    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            //I think this is how you do it, not sureeee

            float rand = Random.Range(0.5f, 1);
            Debug.Log("rand" + rand);
            //obstacle.transform.localScale = Vector3(2, 1, 1);
            Instantiate(obstacle, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;

            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }

        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }

    }
}
