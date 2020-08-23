using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject obstacle;

    private float timeBtwSpawn;
    private float startTimeBtwSpawn = 0.795f;
    //public float decreaseTime;
    //public float minTime = 0.1f;
    public int MaxEmptySpaces = 3;

    private GameObject previousObject;

    // The pieces of the platform 
    public GameObject startPiece;
    public GameObject middlePiece;
    public GameObject endPiece;
    public GameObject platform;

    // Indicator of which platform to spawn
    private int platformToSpawn = 1;


    private int numberOfMiddleSpaces = 2;
    private int numberOfEmptySpaces = 1;

    private void Start()
    {
        previousObject = Instantiate(platform, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }


    // ====== ====== ====== ====== ====== ====== ====== ====== ====== ====== 
    // OLD UPDATE METHOD WITH TIME
    // ====== ====== ====== ====== ====== ====== ====== ====== ====== ====== 
    //private void Update()
    //{
    //    if (timeBtwSpawn <= 0)
    //    {

    //        if (platformToSpawn == 1)
    //        {
    //            Instantiate(startPiece, transform.position, Quaternion.identity);
    //            platformToSpawn = 2;
    //        }
    //        else if (platformToSpawn == 2)
    //        {
    //            Instantiate(middlePiece, transform.position, Quaternion.identity);
    //            numberOfMiddleSpaces -= 1;

    //            if (numberOfMiddleSpaces <= 0)
    //            {
    //                numberOfMiddleSpaces = Random.Range(1, 4);
    //                platformToSpawn = 3;
    //            }
    //        }
    //        else if (platformToSpawn == 3)
    //        {
    //            Instantiate(endPiece, transform.position, Quaternion.identity);
    //            platformToSpawn = 0;
    //        }
    //        else
    //        {
    //            if (numberOfEmptySpaces <= 1)
    //            {
    //                platformToSpawn = 1;
    //                numberOfEmptySpaces = Random.Range(1, 1);
    //            }
    //            else
    //            {
    //                numberOfEmptySpaces -= 1;
    //            }
    //        }


    //        timeBtwSpawn = startTimeBtwSpawn;
    //        if (startTimeBtwSpawn > minTime)
    //        {
    //            startTimeBtwSpawn -= decreaseTime;
    //        }

    //    }
    //    else
    //    {
    //        timeBtwSpawn -= Time.deltaTime;
    //    }

    //}


    // ====== ====== ====== ====== ====== ====== ====== ====== ====== ====== 
    // NEW UPDATE METHOD WITH DISTANCE CALCULATION
    // ====== ====== ====== ====== ====== ====== ====== ====== ====== ======
    //private void Update()
    //{
    //    Debug.Log("previousObject.transform.position.x:" + previousObject.transform.position.x);

    //    if (previousObject.transform.position.x <= 26.00f)
    //    {

    //        if (platformToSpawn == 1)
    //        {
    //            previousObject = Instantiate(startPiece, transform.position, Quaternion.identity);
    //            platformToSpawn = 2;
    //        }
    //        else if (platformToSpawn == 2)
    //        {
    //            previousObject = Instantiate(middlePiece, transform.position, Quaternion.identity);
    //            numberOfMiddleSpaces -= 1;

    //            if (numberOfMiddleSpaces <= 0)
    //            {
    //                numberOfMiddleSpaces = Random.Range(1, 4);
    //                platformToSpawn = 3;
    //            }
    //        }
    //        else if (platformToSpawn == 3)
    //        {
    //            previousObject = Instantiate(endPiece, transform.position, Quaternion.identity);
    //            platformToSpawn = 0;
    //        }
    //        else
    //        {
    //            if (numberOfEmptySpaces <= 0)
    //            {                    
    //                platformToSpawn = 1;
    //                numberOfEmptySpaces = Random.Range(1, MaxEmptySpaces);
    //            }
    //            else
    //            {
    //                numberOfEmptySpaces -= 1;
    //                previousObject = Instantiate(middlePiece,new Vector3(transform.position.x, 20f, 20f), Quaternion.identity);
    //            }
    //        }


    //    }



    //}

    private void Update()
    {
        //RectTransform rt = (RectTransform)previousObject.transform;
        //float width = rt.rect.width;
        //float height = rt.rect.height;
        //Debug.Log("previousObject.transform.position.x:" + previousObject.transform.position.x);
        //Debug.Log("width:" + width);
        Debug.Log("previousObject. edge.position.x:" + previousObject.GetComponent<PlatformBuilder>().GetWidth());

        float prevEdge = previousObject.GetComponent<PlatformBuilder>().GetEdgePosition();
        float width = previousObject.GetComponent<PlatformBuilder>().GetWidth();

        if (prevEdge <= 24.8f )
        {
            previousObject = Instantiate(platform, transform.position, Quaternion.identity);

        }



    }


}
