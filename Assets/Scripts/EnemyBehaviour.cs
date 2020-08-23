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

    //public GameObject playerAmmo;
    public GameObject splashEffect;
    public GameObject cameraObject;


    private float destroyDistance = -20f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        bcol = gameObject.GetComponent<BoxCollider2D>();
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera"); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Damage the Player
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damageAmount);
            // Shake screen when player gets hit.
            cameraObject.GetComponent<CameraShaker>().TriggerShake();
            // Destroy the Virus.
            Destroy(this.gameObject);            
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            // Take damage from the bullet.
            AmmoBehaviour bullet = other.gameObject.GetComponent<AmmoBehaviour>();
            TakeDamage(bullet.damageAmount);
            // Make the splash effect.
            Instantiate(splashEffect, transform.position, Quaternion.identity);
            // Destroy the bullet.
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
            movement = new Vector2(Random.Range(-0.5f, 0.3f), Random.Range(0, 0.5f));

        } else
        {
            movement = new Vector2(Random.Range(-0.5f, 0.3f), Random.Range(-0.5f, 0.2f));
        }

        if (transform.position.x <= destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }

}
