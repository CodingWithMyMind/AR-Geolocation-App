using Mapbox.Unity.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class POIObject : MonoBehaviour
{
    public string ARSceneToEnter = null;

    public string POIMapName = "POI";
   private Text POIMapNameText;

    public string locationString;
    public string message;
    public bool collected;


    public GameObject txtStatus;
    public GameObject StatusPanel;

    

    private void OnEnable()
    {

        POIMapNameText = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>(); 
       // POIMapNameText = transform.Find("Text").gameObject.
        txtStatus = GameObject.Find("txtStatus");
        StatusPanel = GameObject.Find("StatusPanel");

    }
    // Start is called before the first frame update
    void Start()
    {
        if (ARSceneToEnter == null)
        {
            ARSceneToEnter = "ARcene1";
        }
        if (POIMapNameText)
        {
            POIMapNameText.text = POIMapName;
        }

        //DisplayStatus("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Enter POI
        if(other.tag == "Player")
        {
            DisplayStatus(message);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Exit POI
        if (other.tag == "Player")
        {
            HideStatus();
        }
    }

    public void DisplayStatus(string msg)
    {
        StatusPanel.SetActive(true);
        txtStatus.GetComponent<Text>().text = msg;
        //Invoke("HideStatus", 2);
    }
    
    public void HideStatus()
    {
        StatusPanel.SetActive(false);
    }


}
