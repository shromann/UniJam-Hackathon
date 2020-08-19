using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpAmount;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            Vector2 jumpPower = new Vector2(0, jumpAmount);
            rb.AddForce(jumpPower);
        }

    }
}
