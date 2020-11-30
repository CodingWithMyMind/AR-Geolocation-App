using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject UIButtonToEnterAR;

    private static Player _instance;

    public bool AtPOI;

    public string CurrentPOI;

    private GameObject map;

    private CapsuleCollider playerCollider;
    private float startColliderRadius;

    

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
        CurrentPOI = "POI1";
        Instance = this;
        UIButtonToEnterAR = GameObject.Find("EnterARButton");

        playerCollider = this.gameObject.GetComponent<CapsuleCollider>();
        startColliderRadius = playerCollider.radius;
        map = GameObject.Find("Map");
    }

    // Update is called once per frame
    void Update()
    {
        playerCollider.radius = map.transform.localScale.x * startColliderRadius;
    }

    private void OnTriggerEnter(Collider other)
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "POI")
        {
            UIButtonToEnterAR.SetActive(true);
            AtPOI = true;
            Debug.Log("Player enter POI");
            
            CurrentPOI = other.gameObject.GetComponentInParent<POIObject>().ARSceneToEnter;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "POI")
        {
            AtPOI = false;
            UIButtonToEnterAR.SetActive(false);
            Debug.Log("Player exit POI");
            CurrentPOI = "Exited" + other.gameObject.name;
        }
    }
}
