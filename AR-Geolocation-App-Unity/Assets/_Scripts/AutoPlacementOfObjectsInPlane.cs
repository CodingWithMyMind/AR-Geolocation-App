using UnityEngine;
using UnityEngine.UI;


using System.Collections;
using System.Collections.Generic;

using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class AutoPlacementOfObjectsInPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject placedPrefab;

    [SerializeField]
    private GameObject placedPlant;


    private GameObject placedObject;

    [SerializeField]
    private ARPlaneManager arPlaneManager;

    ARPlane arPlane;

    void Awake() 
    {
        //dismissButton.onClick.AddListener(Dismiss);
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlaneChanged;
    }

    private void Update()
    {
        
    }

    public void Spawn()
    {
        // Spawn the object as a child of the plane. This will solve any rotation issues
        GameObject obj = Instantiate(placedPlant, Vector3.zero, Quaternion.identity,arPlane.transform) as GameObject;

        /* Move the object to where you want withing in the dimensions of the plane */
        // random the x and z position between bounds
        
        var x_rand = Random.Range(-arPlane.extents.x, arPlane.extents.x);
        var y_rand = Random.Range(-arPlane.extents.y, arPlane.extents.y);

        // Random the y position from the smallest bewteen x and z
        //var z_rand = x_rand > z_rand ? Random.Range(0, z_rand) : Random.Range(0, x_rand);

        // Now move the object
        // Since the object is a child of the plane it will automatically handle rotational offset
        obj.transform.position = new Vector3(x_rand, y_rand, 0);

        // Now unassign the parent
        obj.transform.parent = null;
    }


    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if(args.added != null && placedObject == null)
        {
            arPlane = args.added[0];
            placedObject = Instantiate(placedPrefab, arPlane.transform.position, Quaternion.identity);
        }
    }

    //private void Dismiss() => welcomePanel.SetActive(false);
}
