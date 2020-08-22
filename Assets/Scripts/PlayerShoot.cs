using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    private float nextFire = 0.0F;
    private float spawnDistance = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire )
        {
            //Debug.Log("Time " + Time.time);
            nextFire = Time.time + fireRate;
            Instantiate(bullet, new Vector2 (transform.position.x + spawnDistance, transform.position.y),
                Quaternion.identity);

        }
    }
}
