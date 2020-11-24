using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource OpenSFX;
    // Start is called before the first frame update
    void Start()
    {
        OpenSFX.Play();
        Invoke("BGM", 2);
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

  
}
