using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerHandle : MonoBehaviour
{
    public Text TimerDisplay;
    
    private float countValue;
    // Start is called before the first frame update
    void Start()
    {
        countValue = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        float timer = Time.time - countValue;

        string Minutes = ((int)timer / 60).ToString("d2");
        string seconds = ((int)timer % 60).ToString("d2");

        TimerDisplay.text = string.Format("{0:00}:{1:00}", Minutes, seconds);
    }




}
