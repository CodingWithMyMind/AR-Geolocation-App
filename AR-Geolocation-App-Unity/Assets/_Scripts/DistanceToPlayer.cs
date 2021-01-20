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

public class DistanceToPlayer : MonoBehaviour
{
    public string pointToMeasureFrom;
    Text textBox;

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

    // Start is called before the first frame update
    void Start()
    {
        textBox = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        NewDistanceToPlayer();
    }


    private void NewDistanceToPlayer()
    {
        // player location as array with 0 being x/latitude and 1 being y/longitude
        double[] playerLocation = new double[] { LocationProvider.CurrentLocation.LatitudeLongitude.x, LocationProvider.CurrentLocation.LatitudeLongitude.y };
        // first turn our Point B string of the location into a Vector2D
        Mapbox.Utils.Vector2d pointToMeasureToVector = Conversions.StringToLatLon(pointToMeasureFrom);

        // Turn point B into a double array
        double[] pointToMeasureToLocation = new double[] { pointToMeasureToVector.x, pointToMeasureToVector.y };
        // cheap ruer set up
        CheapRuler cr = new CheapRuler(playerLocation[1], CheapRulerUnits.Meters);
        // measure distance
        double distance = cr.Distance(playerLocation, pointToMeasureToLocation);
        // final output string used for formatting
        string distanceString;

        // decide if show meters of kilometers
        distance = Math.Round(distance, 0);
        if (distance < 1000)
        {
            distanceString = distance + "m";
        }
        else
        {
            distanceString = Math.Round((distance / 1000), 0).ToString() + "km";
        }
        // render
        textBox.text = distanceString;
    }

}
