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

        Instance = this;
    }

    void Start()
    {

        state = State.Menu;
        EnterMenu();
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

    /* 
     * Public Functions to be called from UI elements or from other scripts etc
     * these will then change the game state to be ran every frame. Can also be 
     * used like constructers to set up play states 
    */

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


}
