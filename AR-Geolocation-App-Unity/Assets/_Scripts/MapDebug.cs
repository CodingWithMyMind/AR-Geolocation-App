using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapDebug : MonoBehaviour
{
    public GameObject UIButtonToEnterAR;
    public Toggle toggle;

    bool ShouldEnterARMode = false;
    // Start is called before the first frame update
    void Start()
    {
        UIButtonToEnterAR = GameObject.Find("EnterARButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableARMode()
    {
        bool currentUIState = UIButtonToEnterAR.activeSelf;
        UIButtonToEnterAR.SetActive(!currentUIState);
    }
}
