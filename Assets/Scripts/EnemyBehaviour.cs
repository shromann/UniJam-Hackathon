using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 4f;
    public int hp = 1;
    public int damageAmount = 1;


    public LayerMask platformsLayer;

    // Random Motion
    private Rigidbody2D rb;
    private float accelerationTime = 1f;
    private float maxSpeed = 10f;
    private Vector2 movement;
    private float timeLeft;


    private BoxCollider2D bcol;

    public GameObject playerAmmo;
    public GameObject splashEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb = gameObject.GetComponent<Rigidbody2D>();
        //Debug.Log(playerGroundHeight);
        bcol = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damageAmount);
            Destroy(this.gameObject);            
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            AmmoBehaviour bullet = other.gameObject.GetComponent<AmmoBehaviour>();
            TakeDamage(bullet.damageAmount);
            Instantiate(splashEffect, transform.position, Quaternion.identity);
            Destroy(other.gameObject); 
        }

    }

    private bool groundCheck()
    {
        // Create the raycast fromt they player which extends slightly below the player 
        RaycastHit2D onGround = Physics2D.BoxCast(bcol.bounds.center,
            bcol.bounds.size, 0f, Vector2.down, bcol.bounds.extents.y + 1f, platformsLayer);


        return (onGround.collider != null);
    }

    public void TakeDamage(int damageAmount)
    {
        hp -= damageAmount;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // From Platform script 

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (groundCheck())
        {
            movement = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0, 0.5f));

        } else
        {
            movement = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }

}
