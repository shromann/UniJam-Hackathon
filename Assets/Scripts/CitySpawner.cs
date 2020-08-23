using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySpawner : MonoBehaviour
{ 

    public GameObject city;

    private float timer = 0;
    public float spawnTime = 10f;


    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnTime)
        {
            
            Instantiate(city, transform.position, Quaternion.identity);
            
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
