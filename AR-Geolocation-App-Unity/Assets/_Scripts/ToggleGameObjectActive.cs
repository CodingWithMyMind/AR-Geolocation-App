using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObjectActive : MonoBehaviour
{
    public void ToggleGameObject(GameObject objectToToggle)
    {
        bool currentState = objectToToggle.activeSelf;
        objectToToggle.SetActive(!currentState);
    }
}
