using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    
    public enum State { Menu, Map, ARMode, Locations, Gallery, Info};

    public GameObject MenuUI, MapUI, ARModeUI, LocationsUI, GalleryUI, InfoUI;

    public GameObject MapNavUI, ARModeNavUI, LocationsNavUI, GalleryNavUI, InfoNavUI;

    

    public State state;


    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
        set
        {
            if (_instance == null)
                _instance = value;
        }
    }

    private void Awake()
    {

//#if UNITY_STANDALONE_WIN
//        windowsBuild = true;
//#endif

//#if UNITY_IOS
  //      IOSBuild = true;
//#endif

       


/*           GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
*/

        Instance = this;

    }

    void Start()
    {
        // First time check if has already done the onboarding
        if (PlayerPrefs.GetInt("onBoarding") == 0)
        {
            // if not then enter the main menu/onboarding
            EnterMenu();
            // Set player prefs so know has already completed onboarding
            PlayerPrefs.SetInt("onBoarding", 1);
            
        }
        else
        {
            // if player has already completed onboarding then send them to the map
            EnterMap();
        }
    }

    void Update()
    {
        switch (state)
        {
            case State.Menu:
                {
                    break;
                }

            case State.Map:
                {
                    break;
                }

            case State.ARMode:
                {

                    break;
                }

            case State.Locations:
                {

                    break;
                }

            case State.Gallery:
                {


                    break;
                }

            case State.Info:
                {

                    break;
                }
        }
    }

    public void TurnOnUI(GameObject UIToTurnOn, GameObject UIButtonToTurnOn)
    {
        // Set all UI screens off
        MenuUI.SetActive(false);
        MapUI.SetActive(false);
        ARModeUI.SetActive(false);
        LocationsUI.SetActive(false);
        InfoUI.SetActive(false);
        GalleryUI.SetActive(false);

        // sett all UI button images off
        MapNavUI.SetActive(false);
        ARModeNavUI.SetActive(false);
        LocationsNavUI.SetActive(false);
        InfoNavUI.SetActive(false);
        GalleryNavUI.SetActive(false);

        // turn on current UI and Nav Button active
        UIToTurnOn.SetActive(true);
        UIButtonToTurnOn.SetActive(true);
    }


    public void EnterMenu()
    {


        TurnOnUI(MenuUI,MapNavUI);
   
        state = State.Menu;
    }



    // do once here

    public void EnterMap()
    {
        TurnOnUI(MapUI,MapNavUI);



        state = State.Map;
    }

    public void EnterARMode()
    {
        TurnOnUI(ARModeUI,ARModeNavUI);

        SceneManager.LoadSceneAsync(Player.Instance.ARSceneToEnter);

        state = State.ARMode;
    }

    public void EnterGallery()
    {
        TurnOnUI(GalleryUI,GalleryNavUI);


        state = State.Gallery;
    }

    public void EnterInfo()
    {
        TurnOnUI(InfoUI,InfoNavUI);

        state = State.Info;
    }

    public void EnterLocations()
    {
        TurnOnUI(LocationsUI,LocationsNavUI);


        state = State.Locations;
    }

    public void ClearSavedData()
    {
        PlayerPrefs.SetInt("onBoarding", 0);
    }

   
    void OnApplicationQuit()
    {
        // clear the saved data on app quit for testing purposes
        ClearSavedData();
        Debug.Log("Application ending after " + Time.time + " seconds");
    }

    public void OpenBrower()
    {
        Application.OpenURL("https://sites.google.com/view/deakinlpgeo-ar");
    }


}
