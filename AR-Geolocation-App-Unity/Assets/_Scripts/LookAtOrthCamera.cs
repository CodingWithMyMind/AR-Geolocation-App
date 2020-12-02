using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;


public class LookAtOrthCamera : MonoBehaviour
{
    Camera camera;

  
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = camera.transform.rotation;
        //transform.localScale = _mapManager.transform
    }
}
