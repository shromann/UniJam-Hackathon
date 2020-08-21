using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehaviour : MonoBehaviour
{
    public int speed = 1;
    public int damageAmount = 1;
    public int destroyDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // https://answers.unity.com/questions/261556/how-to-tell-if-my-character-hit-a-collider-of-a-ce.html
        //Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            collision.gameObject.GetComponent<EnemyBehaviour>().damage(damageAmount);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // From Platform script
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Should destroy ammo once it reaches a certain point off screen
        //if (gameObject.transform.position.x <= destroyDistance)
        //{
        //    Destroy(gameObject);
        //}

    }
}
