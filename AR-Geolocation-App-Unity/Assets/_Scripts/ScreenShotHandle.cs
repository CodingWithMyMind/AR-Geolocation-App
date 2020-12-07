using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotHandle : MonoBehaviour
{
    public GameObject Holder;
    public AudioSource CaptureSound;

    [SerializeField]
    


    public void ScreenShot()
    {
        StartCoroutine("ScreenCaptureF");
    }

    IEnumerator ScreenCaptureF()
    {
        CaptureSound.Play();
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "Screenshot" + timeStamp + ".png";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        //ScreenCapture Motion but, It's not needed
        //Instantiate(BlinkMotion, new Vector2(0f, 0f), Quaternion.identity);
 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reappear()
    {
        Invoke("ActiveHolder", 3);
    }

    void ActiveHolder()
    {
        Holder.SetActive(true);
    }
}
