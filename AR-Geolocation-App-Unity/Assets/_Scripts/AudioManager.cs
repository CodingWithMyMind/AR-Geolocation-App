using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public GameObject SidePanel;
    public GameObject PlaceObject;
    public GameObject ResetObject;
    public AudioSource bgm;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource OpenSFX;
    public AudioSource ButtonSound;
    public float animationSpeed;

    private Transform btnReturnToMapTransform;
    private Transform btnPlaceObjectTransform;
    private Transform btnResetObjectTransform;
    private Transform btnRmenuTransform;

    private float animationDelay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        OpenSFX.Play();
        Invoke("BGM", 1);
        //btnObjATransform = GameObject.Find("ObjA").GetComponent<Transform>();
        btnReturnToMapTransform = GameObject.Find("ReturnToMap").GetComponent<Transform>();
        btnPlaceObjectTransform = GameObject.Find("PlaceObject").GetComponent<Transform>();
        btnResetObjectTransform = GameObject.Find("ResetObject").GetComponent<Transform>();
        btnRmenuTransform = GameObject.Find("ReturnToMenu").GetComponent<Transform>();
        
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
        btnPlaceObjectTransform.localScale = new Vector3(1, 1, 1);
        btnResetObjectTransform.localScale = new Vector3(1, 1, 1);
        btnRmenuTransform.localScale = new Vector3(1, 1, 1);
        //btnObjATransform.localScale = new Vector3(1, 1, 1);


    }

    public void buttonSound()
    {
        ButtonSound.Play();

    }
    public void buttonOnClick(string buttonName)
    {
        ButtonSound.Play();
        switch (buttonName)
        {
            
        case "ReturnToMap":    
                animation(btnReturnToMapTransform);
                Invoke("EnterARScene", animationSpeed + animationDelay);
                break;
        case "PlaceObject":
                animation(btnPlaceObjectTransform);
                Invoke("SetSidePanel", animationSpeed + animationDelay);
                break;
        case "ResetS":
                animation(btnResetObjectTransform);             
                break;
            case "ReturnMenu":
                BacktoMenu();
                animation(btnRmenuTransform);
                break;






            default:
                break;
        }
    }

    void EnterARScene()
    {
        SceneManager.LoadScene("MapSceneLight", LoadSceneMode.Single);
    }

    void SetSidePanel()
    {
        SidePanel.SetActive(true);
        PlaceObject.SetActive(false);
    }

    void BacktoMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    



  
}
