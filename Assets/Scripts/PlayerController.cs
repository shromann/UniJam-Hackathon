using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpAmount;
    public GameObject platform;

    private Rigidbody rb;
    private bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
        
    //}

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }

     void OnCollisionExit(Collision collision)
    {
        onGround = false;        
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
