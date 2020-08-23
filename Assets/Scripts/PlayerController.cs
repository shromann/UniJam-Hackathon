using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // By how much should the player jump
    public float jumpAmount;

    // Player health
    public int health = 5;

    // Platform
    //public GameObject platform;
    public LayerMask platformsLayer;

    private Rigidbody2D rb; 
    private BoxCollider2D bcol;

    // Bridge Object
    public GameObject bridge;

    // Screen Vector
    private Vector2 screenBounds;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //Debug.Log(playerGroundHeight);
        bcol = gameObject.GetComponent<BoxCollider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // https://unitycodemonkey.com/video.php?v=c3iEl5AwUF8
    private bool groundCheck()
    {
        // Create the raycast fromt they player which extends slightly below the player 
        RaycastHit2D onGround = Physics2D.BoxCast(bcol.bounds.center,
            bcol.bounds.size, 0f, Vector2.down, bcol.bounds.extents.y + 0.1f, platformsLayer);

       
        return (onGround.collider != null);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && groundCheck())
        {
            Vector2 moveForce = new Vector2(0, jumpAmount);
            rb.AddForce(moveForce);

        }
        if (Input.GetKey(KeyCode.LeftArrow) && groundCheck() && transform.position.x > 1.2f - screenBounds.x)
        {
            Vector2 moveForce = new Vector2(-10f, 0);
            rb.AddForce(moveForce);
            transform.Translate(Vector2.left * 2f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) && groundCheck() && transform.position.x < screenBounds.x - 1.2f)
        {
            Vector2 moveForce = new Vector2(10f, 0);
            rb.AddForce(moveForce);
            transform.Translate(Vector2.right * 2f * Time.deltaTime);
        }


        // CREATE BRIDGES IN THREE POSITIONS
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log("CREATE BRIDGE");
        //    Instantiate(bridge, new Vector3(8.5f ,8f, transform.position.z), Quaternion.identity);
        //}

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("CREATE BRIDGE");
            Instantiate(bridge, new Vector3(6f, 8f, transform.position.z), Quaternion.identity);
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("CREATE BRIDGE");
        //    Instantiate(bridge, new Vector3(3.5f, 8f, transform.position.z), Quaternion.identity);
        //}

    }

    public void TakeDamage(int damageAmount)
    {
            health -= damageAmount;
            Debug.Log("HEALTH " + health);

    }
}
