using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject obstacle;

    private float timeBtwSpawn;
    private float startTimeBtwSpawn = 0.775f;
    public float decreaseTime;
    public float minTime = 0.1f;


    // The pieces of the platform 
    public GameObject startPiece;
    public GameObject middlePiece;
    public GameObject endPiece;

    // Indicator of which platform to spawn
    private int platformToSpawn = 1;


    private int numberOfMiddleSpaces = 2;
    private int numberOfEmptySpaces = 1;

    

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            
            if (platformToSpawn == 1)
            {
                Instantiate(startPiece, transform.position, Quaternion.identity);
                platformToSpawn = 2;
            }
            else if (platformToSpawn == 2)
            {
                Instantiate(middlePiece, transform.position, Quaternion.identity);
                numberOfMiddleSpaces -= 1;

                if(numberOfMiddleSpaces <= 0)
                {
                    numberOfMiddleSpaces = Random.Range(1, 4);
                    platformToSpawn = 3;
                }
            }
            else if (platformToSpawn == 3)
            {
                Instantiate(endPiece, transform.position, Quaternion.identity);
                platformToSpawn = 0;
            } else
            {
                if (numberOfEmptySpaces <= 1)
                {
                    platformToSpawn = 1;
                    numberOfEmptySpaces = Random.Range(1, 1);
                }
                else
                {
                    numberOfEmptySpaces -= 1;
                }
            }


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
