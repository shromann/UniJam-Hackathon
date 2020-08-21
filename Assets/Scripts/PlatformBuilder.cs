using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBuilder : MonoBehaviour
{
    // When setting these, remember that the platforms will always have a length
    // of at least 1
    public int maxLength;
    public int minLength;

    // The pieces of the platform 
    public GameObject startPiece;
    public GameObject middlePiece;
    public GameObject endPiece;

    private void Awake()
    {
        // Generate the size of the platform 
        int platformSize = Random.Range(minLength, maxLength);

        // get the widths of the platform pieces do can place them side by side
        float startSize = startPiece.GetComponent<SpriteRenderer>().bounds.size.x;
        float middleSize = middlePiece.GetComponent<SpriteRenderer>().bounds.size.x;

        // Counter for looping over making middle pieces 
        int i = 0;
        float currentPlatformWidth = 0;

        // Place the first piece of the platform down 
        Instantiate(startPiece, new Vector3(0, 0, 1), Quaternion.identity, gameObject.transform);
        currentPlatformWidth += startSize;

        // Make the platform have a length of at least 1
        do
        {
            Instantiate(middlePiece, new Vector3 (currentPlatformWidth, 0 , 1),
                Quaternion.identity, gameObject.transform);
            i++;
            currentPlatformWidth += middleSize;

        } while (i <= platformSize);

        // Place the last piece of the platform down 
        Instantiate(endPiece, new Vector3(currentPlatformWidth, 0, 1),
            Quaternion.identity, gameObject.transform);
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
