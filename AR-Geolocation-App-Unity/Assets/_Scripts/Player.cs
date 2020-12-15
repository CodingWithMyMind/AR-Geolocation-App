using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject UIButtonToEnterAR;

    public GameObject CurrentPOIGameObject;
    public GameObject POII1;
    public GameObject POI3;

    private static Player _instance;

    public bool AtPOI;
    public bool BenchesPOI = false;
    public bool KenLPOI = false;


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
        POII1 = GameObject.Find("CheckPOI1");
        POI3 = GameObject.Find("CheckPOI3");
        ARSceneToEnter = "POI1";
        Instance = this;
        UIButtonToEnterAR = GameObject.Find("EnterARButton");








        playerCollider = this.gameObject.GetComponent<BoxCollider>();

        startColliderSize = playerCollider.size;
        map = GameObject.Find("Map");


        ArrivedFeedback.SetActive(false);
        UIButtonToEnterAR.SetActive(false);

    }

    void Update()
    {
        if (BenchesPOI == true)
            {
            POI3.GetComponent<Toggle>().isOn = true;
            }

        if (KenLPOI == true)
        {
            POII1.GetComponent<Toggle>().isOn = true;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //playerCollider.size = map.transform.localScale.x * startColliderSize;


    }

    private void OnTriggerEnter(Collider other)
    {

    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "POI")
        {

            //POI3 = GameObject.Find("CheckPOI3");
            UIButtonToEnterAR.SetActive(true);
            AtPOI = true;
            CurrentPOIGameObject = other.gameObject;
            ArrivedFeedback.SetActive(true);
            ArrivedText.text = CurrentPOIGameObject.GetComponent<POIObject>().POIMapName;
            BenchesPOI = true;

        }

        if (other.tag == "KenPOI")
        {
            //POII1.GetComponent<Toggle>().isOn = true;
            UIButtonToEnterAR.SetActive(true);
            AtPOI = true;
            

            CurrentPOIGameObject = other.gameObject;
            ArrivedFeedback.SetActive(true);
            ArrivedText.text = CurrentPOIGameObject.GetComponent<POIObject>().POIMapName;
            KenLPOI = true;



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
