using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject UIButtonToEnterAR;

    public GameObject CurrentPOIGameObject;
    public GameObject POI1;

    private static Player _instance;

    public bool AtPOI;


    public string ARSceneToEnter;

    private GameObject map;

    private BoxCollider playerCollider;
    private Vector3 startColliderSize;

    public GameObject ArrivedFeedback;
    public Text ArrivedText;

    

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
        POI1 = GameObject.Find("CheckPOI1");


        playerCollider = this.gameObject.GetComponent<BoxCollider>();

        startColliderSize = playerCollider.size;
        map = GameObject.Find("Map");


        ArrivedFeedback.SetActive(false);
        UIButtonToEnterAR.SetActive(false);

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

            CurrentPOIGameObject = other.gameObject;
            ArrivedFeedback.SetActive(true);
            ArrivedText.text = CurrentPOIGameObject.GetComponent<POIObject>().POIMapName;

            POI1.GetComponent<Toggle>().isOn = true;
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
            ArrivedFeedback.SetActive(false);
            Debug.Log("Player exit POI");
            ARSceneToEnter = "Exited";
        }
    }


}
