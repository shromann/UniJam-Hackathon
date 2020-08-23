using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private float speed = 5f;

    private float destroyDistance = -20f;

    private GameObject cameraObject;
    private bool hasTouchedOnce = false;

    private void Start()
    {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Bridge"))
        //{
        //    Debug.Log("HIT BRIDGE");
        //    HingeJoint2D joint = (HingeJoint2D)this.gameObject.AddComponent<HingeJoint2D>();
        //    joint.breakForce = 45;
        //    joint.breakTorque = 45;
        //    joint.connectedBody = collision.rigidbody;
        //}

        if (collision.gameObject.CompareTag("Platform"))
        {
          
            // Effect on Bridge Touching the ground.
            if (!hasTouchedOnce)
            {
                cameraObject.GetComponent<CameraShaker>().TriggerShake(0.05f);
                hasTouchedOnce = true;
            }
            
            
        }
    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
