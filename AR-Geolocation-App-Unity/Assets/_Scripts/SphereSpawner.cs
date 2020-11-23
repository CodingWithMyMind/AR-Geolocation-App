using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnObject;
    private PlacementIndicator placementIndicator;
    

    private float destroyafterSeconds = 5.0F;
    private float spawnfrequency = 1.0f;
    private float timer = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        
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

    public void PlaceObject()
    {
        GameObject ObjectA = Instantiate(SpawnObject, placementIndicator.transform.position, placementIndicator.transform.rotation);
            Destroy(ObjectA, destroyafterSeconds);
        }






}
