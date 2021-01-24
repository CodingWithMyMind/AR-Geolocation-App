using Mapbox.Unity.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Location;
using KDTree;
using Mapbox.CheapRulerCs;
using System;

public class POIObject : MonoBehaviour
{

    //public Text distanceFromPlayerLocationsUI;

    public GameObject ButtonToEnterAR;

    public string ARSceneToEnter = null;

    public string POIMapName = "POI";
    private Text POIMapNameText;

    public string locationString;
    public string message;

    public GameObject mapPOIPinUI;

    public bool playerAtThisPOI = false;

    ILocationProvider _locationProvider;
    ILocationProvider LocationProvider
    {
        get
        {
            if (_locationProvider == null)
            {
                _locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
            }

            return _locationProvider;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player is inside of " + gameObject.name);
            
            playerAtThisPOI = true;
            Player.Instance.ARSceneToEnter = ARSceneToEnter;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player exit poi");
            playerAtThisPOI = false;
        }
    }




    private void OnEnable()
    {
        POIMapNameText = this.gameObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>(); 
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










    }

    private void DistanceToPlayer()
    {
        double[] playerLocation = new double[] { LocationProvider.CurrentLocation.LatitudeLongitude.x, LocationProvider.CurrentLocation.LatitudeLongitude.y };
        var loc = Conversions.StringToLatLon(locationString);

        double[] poiLoc = new double[] { loc.x, loc.y };
        CheapRuler cr = new CheapRuler(playerLocation[1], CheapRulerUnits.Meters);

        double distance = cr.Distance(playerLocation, poiLoc);

        string distanceString;


        distance = Math.Round(distance, 0);

        if (distance < 1000)
        {
            distanceString = distance + "m";
        }
        else
        {
            distanceString = Math.Round((distance / 1000),0).ToString() + "km";
        }

        mapPOIPinUI.GetComponent<MapPOIUI>().UpdateDistanceFromPlayer(distanceString);
        //distanceFromPlayerLocationsUI.text = distanceString;


        //Debug.Log(gameObject.name + " is " + distance + " away from player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        DistanceToPlayer();
        if (playerAtThisPOI)
        {
            //Debug.Log("hiding content");
            mapPOIPinUI.GetComponent<MapPOIUI>().HideContent();
        }
        else
        {
            //Debug.Log("showing content");
            mapPOIPinUI.GetComponent<MapPOIUI>().ShowContent();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Enter POI
        if(other.tag == "Player")
        {
            DisplayStatus(message);
        }
    }



    public void DisplayStatus(string msg)
    {
        //StatusPanel.SetActive(true);
        //txtStatus.GetComponent<Text>().text = msg;
        //Invoke("HideStatus", 2);
    }
    
    public void HideStatus()
    {
        //StatusPanel.SetActive(false);
    }


}
