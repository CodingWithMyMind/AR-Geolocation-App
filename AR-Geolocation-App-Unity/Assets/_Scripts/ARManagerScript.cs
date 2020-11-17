using Mapbox.Unity.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ARManagerScript : MonoBehaviour
{
    public GameObject OnBoardPanel;
    public GameObject TextMessagePanel;
    public Text txtM;
   

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
        SceneManager.LoadScene("MapSceneLight", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartARScene2()
    {
        Invoke("StartARScene", 5);
        DisplayStatus("Start in 5", 5);
    }

    public void StartARScene()
    {
        OnBoardPanel.SetActive(false);
        
    }

    public void QuitARScene()
    {
        Invoke("Quit", 3);
        DisplayStatus("Thank you for using our software!", 3);
    }

    public void DisplayStatus(string Status, int seconds)
    {
        
        txtM.text = Status;
        TextMessagePanel.SetActive(true);
        Invoke("HideStatus", seconds);
    }

    public void HideStatus()
    {
        TextMessagePanel.SetActive(false);
    }




}
