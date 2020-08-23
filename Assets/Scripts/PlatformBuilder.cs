using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBuilder : MonoBehaviour
{
    // When setting these, remember that the platforms will always have a length
    // of at least 1
    public int maxLength = 3;
    public int minLength = 0;

    // Set how far off the platform should spawn
    private float spawnDistance = 0f;

    private float platformWidth = 0f;

    // Set how far off the platform should destroy
    public float destroyDistance = -50f;

    // The pieces of the platform 
    public GameObject startPiece;
    public GameObject middlePiece;
    public GameObject endPiece;

    public float speed = 5f;
     
    private void Awake()
    {
        int platformSize = Random.Range(minLength, maxLength);

        Debug.Log("platformSize" + platformSize);
        // Get the widths of the platform pieces do can place them side by side
        //float startSize = startPiece.GetComponent<SpriteRenderer>().bounds.size.x - 1;
        //Debug.Log("size of start piece: " + startSize);
        //float middleSize = middlePiece.GetComponent<SpriteRenderer>().bounds.size.x;
        //Debug.Log("Size of middle piece: " + middleSize);

        // Counter for looping over making middle pieces 
        //int i = 0;
        float currentPlatformWidth = 0;
        //platformWidth += 4.15f;

        // Place the first piece of the platform down 
        Instantiate(startPiece, new Vector3(transform.position.x + spawnDistance, transform.position.y, transform.position.z), Quaternion.identity, gameObject.transform);
        currentPlatformWidth += 1;
        spawnDistance += 4.15f;
        platformWidth += 4.15f;

        // Make the platform have a length of at least 1
        for (int i = 0; i <= platformSize; i++)
        {
            Instantiate(middlePiece, new Vector3(transform.position.x + spawnDistance, transform.position.y, transform.position.z), Quaternion.identity, gameObject.transform);
            //currentPlatformWidth += middleSize;
            spawnDistance += 4.15f;
            platformWidth += 4.15f;
        }
        // Place the last piece of the platform down 
        //Instantiate(endPiece, new Vector3(spawnDistance + currentPlatformWidth, 0, 1),
        //    Quaternion.identity, gameObject.transform);

        Instantiate(endPiece, new Vector3(transform.position.x + spawnDistance, transform.position.y, transform.position.z), Quaternion.identity, gameObject.transform);
        platformWidth += 4.15f;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Generate the size of the platform 
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (gameObject.transform.position.x <= destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    public float GetEdgePosition()
    {
        return transform.position.x + platformWidth - 2f;
        //return transform.position.x + platformWidth;
    }

    public float GetWidth()
    {
        return platformWidth;
        //return transform.position.x + platformWidth;
    }
}
