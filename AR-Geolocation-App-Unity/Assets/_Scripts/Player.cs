using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject UIButtonToEnterAR;

    private static Player _instance;

    public bool AtPOI;

    public string CurrentAtPOI;

    public static Player Instance
    {
        get
        {
            return _instance;
        }
        set
        {
            if (_instance == null)
                _instance = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentAtPOI = "Not Entered POI yet";
        Instance = this;
        UIButtonToEnterAR = GameObject.Find("EnterARButton");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "POI")
        {
            UIButtonToEnterAR.SetActive(true);
            AtPOI = true;
            Debug.Log("Player enter POI");
            CurrentAtPOI = other.gameObject.name;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "POI")
        {
            AtPOI = false;
            UIButtonToEnterAR.SetActive(false);
            Debug.Log("Player exit POI");
            CurrentAtPOI = "Exited" + other.gameObject.name;
        }
    }
}
