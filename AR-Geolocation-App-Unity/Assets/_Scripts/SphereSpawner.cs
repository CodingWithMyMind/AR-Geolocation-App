using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField]
    //private GameObject SpawnObjectA;
    //private GameObject SpawnObjectB;
    //private GameObject SpawnObjectC;
    public GameObject[] SpawnObject;
    public GameObject CubeBird;
    public GameObject[] Object;
    
    private PlacementIndicator placementIndicator;
    

    private float destroyafterSeconds = 5.0F;
    private float spawnfrequency = 1.0f;
    private float timer = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        Instantiate(CubeBird, CubeBird.transform.position, CubeBird.transform.rotation );



    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
           {
            GameObject obj = Instantiate(SpawnObject,
                placementIndicator.transform.position, placementIndicator.transform.rotation);
            
        }*/

        /* testing in editor 
        if (timer >= spawnfrequency)
        {
            GameObject obj = Instantiate(SpawnObject,
            placementIndicator.transform.position, placementIndicator.transform.rotation);

            Destroy(obj, destroyafterSeconds);
            timer = 0;
        }
        timer += Time.deltaTime * 1.0f; */
    }

    public void PlaceObjectA()
    {
         Object[0] = Instantiate(SpawnObject[0], placementIndicator.transform.position, placementIndicator.transform.rotation * Quaternion.Euler(270f, 180f, -90f));
            //Destroy(Object[0], destroyafterSeconds);
        }

    public void PlaceObjectB()
    {
         Object[1] = Instantiate(SpawnObject[1], placementIndicator.transform.position, placementIndicator.transform.rotation * Quaternion.Euler(270f, 180f, 0f));
        //Destroy(Object[1], destroyafterSeconds);
    }

    public void PlaceObjectC()
    {
         Object[2] = Instantiate(SpawnObject[2], placementIndicator.transform.position, placementIndicator.transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        //Destroy(Object[2], destroyafterSeconds);
    }


    public void reset()
    {
        Destroy(Object[0]);
        Destroy(Object[1]);
        Destroy(Object[2]);
        
    }








}
