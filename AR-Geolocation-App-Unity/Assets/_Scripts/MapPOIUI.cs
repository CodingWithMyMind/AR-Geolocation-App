using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine.UI;

public class MapPOIUI : MonoBehaviour
{
    Camera camera;
    public Text text;

    public GameObject distanceUI;

    [SerializeField]
    AbstractMap _map;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        //text = gameObject.GetComponent<Text>();
    }

    public void UpdateDistanceFromPlayer(string distance)
    {
        text.text = distance;
    }

    public void ShowContent()
    {
        distanceUI.SetActive(true);
    }
    public void HideContent()
    {
        distanceUI.SetActive(false);

    }


    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.rotation = camera.transform.rotation;
        //transform.localScale = _mapManager.transform
    }
}