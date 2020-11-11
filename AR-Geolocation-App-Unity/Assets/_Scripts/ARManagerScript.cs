using Mapbox.Unity.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterARScene()
    {
        Debug.Log("Entering AR Scene");
        SceneManager.LoadScene("ARScene", LoadSceneMode.Single);
    }

    public void EnterMapScene()
    {
        Debug.Log("Entering AR Scene");
        SceneManager.LoadScene("MapSceneExperimental", LoadSceneMode.Single);
    }
    
}
