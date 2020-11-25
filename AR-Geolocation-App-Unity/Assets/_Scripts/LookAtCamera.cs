using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookAtCamera : MonoBehaviour
{
    bool shouldShakeForAttention = true;
    private Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        if (shouldShakeForAttention)
        {
            InvokeRepeating("ShakeUI", Random.Range(2.0f,3.0f), 6.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
    }
    public void ShakeUI()
    {
        Debug.Log("UI SHake");
        Vector3 strength = new Vector3(0, 0, 20);
        //transform.DOShakeRotation(1f, strength, 3, 0, true);
        transform.DOPunchRotation(strength, 1, 13, 1);
    }
}
