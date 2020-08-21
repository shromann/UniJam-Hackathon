using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject ammo;
    public float spawnDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(ammo, new Vector3 (transform.position.x + spawnDistance, transform.position.y, transform.position.z),
                Quaternion.identity);
        }
    }
}
