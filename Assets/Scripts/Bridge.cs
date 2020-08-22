using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private float speed = 5f;

    private float destroyDistance = -20f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
