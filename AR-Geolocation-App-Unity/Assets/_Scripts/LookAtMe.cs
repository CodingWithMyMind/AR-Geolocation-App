using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookAtMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShakeUI", 2.0f,4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShakeUI()
    {
        Debug.Log("UI SHake");
        transform.DOShakeRotation(1f, 90, 10, 90, true);
    }
}
