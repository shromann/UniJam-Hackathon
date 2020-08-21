using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpAmount;
    public GameObject platform;
    public LayerMask platformsLayer;

    private Rigidbody2D rb;
    //private bool onGround = false;
    private BoxCollider2D bcol;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //Debug.Log(playerGroundHeight);
        bcol = gameObject.GetComponent<BoxCollider2D>();
    }

    // https://unitycodemonkey.com/video.php?v=c3iEl5AwUF8
    private bool groundCheck()
    {
        // Create the raycast fromt they player which extends slightly below the player 
        RaycastHit2D onGround = Physics2D.BoxCast(bcol.bounds.center,
            bcol.bounds.size, 0f, Vector2.down, bcol.bounds.extents.y + 0.1f, platformsLayer);

        Debug.Log(onGround.collider);

        return (onGround.collider != null);
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && groundCheck())
        {
            Vector2 jumpPower = new Vector2(0, jumpAmount);
            rb.AddForce(jumpPower);
        }
    }

}
