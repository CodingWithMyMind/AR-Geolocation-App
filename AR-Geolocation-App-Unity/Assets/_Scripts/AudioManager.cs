using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource OpenSFX;
    public float animationSpeed;

    private Transform btnReturnToMapTransform;
    private Transform btnObjATransform;
    private float animationDelay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        OpenSFX.Play();
        Invoke("BGM", 2);
        btnReturnToMapTransform = GameObject.Find("ReturnToMap").GetComponent<Transform>();
        //btnObjATransform = GameObject.Find("ObjA").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceObjectA()
    {
        audioSource.Play();
    }

    public void PlaceObjectB()
    {
        audioSource2.Play();
    }

    public void PlaceObjectC()
    {
        audioSource3.Play();
    }

    public void BGM()
    {
        bgm.Play();
    }

    public void animation(Transform btnTransform)
    {
        btnTransform.localScale -= new Vector3(0.4f, 0.4f, 0);
        Invoke("finishAnimate", animationSpeed);
    }

    public void finishAnimate()
    {
       btnReturnToMapTransform.localScale = new Vector3(1, 1, 1);
    }

    public void buttonOnClick(string buttonName)
    {
        switch (buttonName)
        {
        case "ReturnToMap":    
            animation(btnReturnToMapTransform);
            Invoke("EnterARScene", animationSpeed + animationDelay);
                break;
            default:
                break;
        }
    }

    void EnterARScene()
    {
        SceneManager.LoadScene("MapSceneLight", LoadSceneMode.Single);
    }

  
}
