using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnObjectAtPlacement : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    private PlacementIndicator placementIndicator;
    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("something");
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        Debug.Log(results.Count);
        return results.Count > 0;
    }

    public void OnMouseDown()
    {
        Debug.Log("something");
        if (!IsPointerOverUIObject())
        {
            Debug.Log("something");
            GameObject instance = Instantiate(ObjectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);

        }
    }
}
