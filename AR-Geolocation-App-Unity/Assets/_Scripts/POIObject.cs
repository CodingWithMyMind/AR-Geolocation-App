using Mapbox.Unity.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIObject : MonoBehaviour
{
    public string message;
    public bool collected;

    public GameObject UIButtonToEnterAR;

    // Start is called before the first frame update
    void Start()
    {
        UIButtonToEnterAR = GameObject.Find("UIButtonToEnterAR");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // entering POI
        if(other.tag == "Player")
        {
            Debug.Log("player intersect with poi with message :" + message);
            UIButtonToEnterAR.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // Exit POI
        if (other.tag == "Player")
        {
            //Debug.Log("player intersect with poi with message :" + message);
            UIButtonToEnterAR.SetActive(false);
        }
    }
}
