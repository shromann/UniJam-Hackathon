using System.Collections;
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
        //rb.velocity = new Vector2(speed, 0);
        //rb.velocity = new Vector2(speed, 0);
        Vector2 bulletForce = new Vector2(300f, 250f);
        rb.AddForce(bulletForce);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // https://answers.unity.com/questions/261556/how-to-tell-if-my-character-hit-a-collider-of-a-ce.html
        //Debug.Log(collision.gameObject.layer);
        if (other.gameObject.CompareTag("Enemy"))
        {
            //GameObject e = Instantiate(explosion) as GameObject;
            //e.transform.position = transform.position;

            //other.gameObject.GetComponent<EnemyBehaviour>().TakeDamage(damageAmount);
            //Destroy(this.gameObject);

        }
        if (other.gameObject.CompareTag("Platform"))
        {
            //GameObject e = Instantiate(explosion) as GameObject;
            //e.transform.position = transform.position;

            //Destroy(other.gameObject);
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
