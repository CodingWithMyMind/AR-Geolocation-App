using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMapScene()
    {
        Debug.Log("Entering Map Scene");
        SceneManager.LoadScene("MapSceneLight", LoadSceneMode.Single);
    }

    public void DebugScene1()
    {
        SceneManager.LoadScene("ARScene1", LoadSceneMode.Single);
    }

    public void DebugScene2()
    {
        SceneManager.LoadScene("ARScene2", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }


}