﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehaviour : MonoBehaviour
{
    
    public int damageAmount = 1;
    public int destroyDistance = 0;

    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    private BoxCollider2D bcol;

    public GameObject explosion;
    public GameObject splashEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); 
        Vector2 bulletForce = new Vector2(300f, 250f);
        rb.AddForce(bulletForce);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // https://answers.unity.com/questions/261556/how-to-tell-if-my-character-hit-a-collider-of-a-ce.html
                
        if (other.gameObject.CompareTag("Platform"))
        { 
            Instantiate(splashEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x > screenBounds.x)
        {
            Destroy(this.gameObject);
        }
         
    }

}
