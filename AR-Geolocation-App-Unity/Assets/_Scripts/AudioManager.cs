using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    // Start is called before the first frame update
    void Start()
    {
        
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

  
}
