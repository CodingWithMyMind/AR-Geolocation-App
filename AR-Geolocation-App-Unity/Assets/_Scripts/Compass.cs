using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float cameraZ = Camera.main.transform.rotation.eulerAngles.y;
        //Debug.Log(cameraZ);

        Vector3 rot = new Vector3(0, 0, cameraZ);

        gameObject.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(rot));
    }
}
