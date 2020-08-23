using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 1f;

    private float destroyDistance = -20f;


    private void Update()
    {

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    
}
