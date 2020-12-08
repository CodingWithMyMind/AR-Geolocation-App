using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject UIButtonToEnterAR;

    public GameObject CurrentPOIGameObject;

    private static Player _instance;

    public bool AtPOI;


    public string ARSceneToEnter;

    private GameObject map;

    private BoxCollider playerCollider;
    private Vector3 startColliderSize;

    

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
        ARSceneToEnter = "POI1";
        Instance = this;
        UIButtonToEnterAR = GameObject.Find("EnterARButton");

        playerCollider = this.gameObject.GetComponent<BoxCollider>();

        startColliderSize = playerCollider.size;
        map = GameObject.Find("Map");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerCollider.size = map.transform.localScale.x * startColliderSize;
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
            other.gameObject.GetComponent<POIObject>().playerAtThisPOI = true;
            
            ARSceneToEnter = other.gameObject.GetComponentInParent<POIObject>().ARSceneToEnter;

            CurrentPOIGameObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "POI")
        {
            Debug.Log("player trying to exit");
            AtPOI = false;
            StartCoroutine("Exit");
            
        }
    }

    // every 2 seconds perform the print()
    private IEnumerator Exit()
    {

        yield return new WaitForSeconds(1f);
        if (!AtPOI)
        {
            UIButtonToEnterAR.SetActive(false);
            CurrentPOIGameObject.GetComponent<POIObject>().playerAtThisPOI = false;
            Debug.Log("Player exit POI");
            ARSceneToEnter = "Exited";
        }
    }


}
