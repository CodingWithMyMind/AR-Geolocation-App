using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotHandle : MonoBehaviour
{
    public GameObject Holder;
    public GameObject BlinkMotion;
    public AudioSource CaptureSound;
    public float BlinkMotionSpeed = 0.3f;
    public float Blinkdelay = 0.5f;

    [SerializeField]
    

    //ScreenShot
    public void ScreenShot()
    {
        StartCoroutine("ScreenCaptureF");
        CaptureSound.Play();
        Invoke("BlinkMotionOn", Blinkdelay);

        //Screenshot that make blink, so it show that sucessful take the screenshot
        Invoke("BlinkMotionOff", Blinkdelay + BlinkMotionSpeed);
    }

    IEnumerator ScreenCaptureF()
    {
        //CaptureSound.Play();
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "Screenshot" + timeStamp + ".png";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        //BlinkMotion.SetActive(true);
        //Invoke("BlinkMotionOff", BlinkMotionSpeed);

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


    void BlinkMotionOn()
    {
        BlinkMotion.SetActive(true);
    }
    void BlinkMotionOff()
    {
        BlinkMotion.SetActive(false);
    }
}
