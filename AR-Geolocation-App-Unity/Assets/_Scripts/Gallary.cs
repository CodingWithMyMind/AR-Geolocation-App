using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class Gallary : MonoBehaviour
{

    [SerializeField]
    GameObject GallaryMenu;
    string[] files = null;
    int CurrentScreenshot = 0;
    // Start is called before the first frame update
    void Start()
    {
        files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");
        if (files.Length > 0)
            DisplayScreenShot();
    }

    void DisplayScreenShot()
    {
        string FileLocation = files[CurrentScreenshot];
        Texture2D texture = FindImage(FileLocation);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        GallaryMenu.GetComponent<Image>().sprite = sp;
    }

    Texture2D FindImage(string filePath)
    {
        Texture2D texture = null;
        byte[] fileBytes;
        if (File.Exists (filePath))
        {
            fileBytes = File.ReadAllBytes(filePath);
            texture = new Texture2D (2, 2, TextureFormat.RGB24, false);
            texture.LoadImage(fileBytes);
        }
        return texture;
    }

    public void NextScreenshot()
    {
        if (files.Length > 0)
        {
            CurrentScreenshot += 1;
            if (CurrentScreenshot > files.Length - 1)
                CurrentScreenshot = 0;
            DisplayScreenShot();
        }
    }

    public void PreviousScreenshot()
    {
        if (files.Length > 0)
        {
            CurrentScreenshot -= 1;
            if (CurrentScreenshot < 0)
                CurrentScreenshot = files.Length - 1;
            DisplayScreenShot();
        }
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("ARScene2", LoadSceneMode.Single);
    }
}
