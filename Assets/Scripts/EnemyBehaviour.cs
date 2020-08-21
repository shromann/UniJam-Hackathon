using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 0;
    public int hp = 1;

    public GameObject playerAmmo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void damage(int damageAmount)
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
        gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }


}
