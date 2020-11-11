using Mapbox.Unity.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class POIObject : MonoBehaviour
{

    public string message;
    public bool collected;


    public GameObject txtStatus;
    public GameObject StatusPanel;

    public GameObject UIButtonToEnterAR;

    private void OnEnable()
    {
        UIButtonToEnterAR = GameObject.Find("Button");
        txtStatus = GameObject.Find("txtStatus");
        StatusPanel = GameObject.Find("StatusPanel");

    }
    // Start is called before the first frame update
    void Start()
    {

        UIButtonToEnterAR = GameObject.Find("Button");
        DisplayStatus("Hello World");
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
            //DisplayStatus("Hello World");
            UIButtonToEnterAR.SetActive(true);
            StatusPanel.SetActive(true);
            DisplayStatus(message);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
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


            StatusPanel.SetActive(false);
            //DisplayStatus("123");
        }
    }

    public void DisplayStatus(string msg)
    {
        StatusPanel.SetActive(true);
        txtStatus.GetComponent<Text>().text = msg;
        Invoke("HideStatus", 2);
    }
    
    public void HideStatus()
    {
        StatusPanel.SetActive(false);
    }


}
