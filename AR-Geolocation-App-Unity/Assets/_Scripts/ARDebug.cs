using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARDebug : MonoBehaviour
{
    bool currentState;
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToggleArrow()
    {
        currentState = arrow.activeSelf;
        arrow.SetActive(!currentState);
    }
}
