using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    private float nextFire = 0.0F;
    private float spawnDistance = 1;

    public AudioSource splashSound;

    private void Start()
    {
        splashSound = Instantiate(splashSound);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire )
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, new Vector2 (transform.position.x + spawnDistance, transform.position.y),
                Quaternion.identity);
            splashSound.Play();

        }
    }
}
