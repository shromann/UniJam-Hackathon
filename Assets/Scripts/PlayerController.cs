using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpAmount;
    public GameObject platform;

    private Rigidbody2D rb;
    private bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.tag);

        if (collision.collider.tag == "Platform")
        {
            onGround = true;
        }
        Debug.Log(onGround);
    }

     void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.name);

        if (collision.collider.tag == "Platform")
        {
            onGround = false;
        }
        Debug.Log(onGround);

    }

    void Update()
    {
        if (Input.GetKeyDown("space") && onGround)
        {
            Vector2 jumpPower = new Vector2(0, jumpAmount);
            rb.AddForce(jumpPower);
        }
    }

}
