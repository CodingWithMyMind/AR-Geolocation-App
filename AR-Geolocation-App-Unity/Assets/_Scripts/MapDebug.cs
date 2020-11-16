using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Location;

public class MapDebug : MonoBehaviour
{
    public GameObject UIDebugPanel;

    public GameObject UIButtonToEnterAR;
    public Toggle toggle;

    public Text currentPOIText;

    public Text coordinateText;
    bool _isInitialized;

    bool ShouldEnterARMode = false;
    // Start is called before the first frame update
    void Start()
    {
        UIButtonToEnterAR = GameObject.Find("EnterARButton");
        LocationProviderFactory.Instance.mapManager.OnInitialized += () => _isInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableDebugging()
    {
        bool currentState = UIDebugPanel.activeSelf;
        UIDebugPanel.SetActive(!currentState);
    }

    public void EnableARMode()
    {
        bool currentUIState = UIButtonToEnterAR.activeSelf;
        UIButtonToEnterAR.SetActive(!currentUIState);
    }


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

    Vector3 _targetPosition;



    void LateUpdate()
    {
        if (_isInitialized)
        {
            var map = LocationProviderFactory.Instance.mapManager;
            //transform.localPosition = map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude);
            coordinateText.text = "Lat: "+ LocationProvider.CurrentLocation.LatitudeLongitude.x.ToString() +" Lon: "+ LocationProvider.CurrentLocation.LatitudeLongitude.y.ToString();


            currentPOIText.text = Player.Instance.CurrentAtPOI;
}
    }
}
