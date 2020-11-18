using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class POI2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterMapScene()
    {
        Debug.Log("Entering Map Scene");
        SceneManager.LoadScene("KenARScene", LoadSceneMode.Single);
    }
}
