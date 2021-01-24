using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMovement : MonoBehaviour
{
    public bool MoveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Loop that will make Bird continue flying across the screen
        {
            if (MoveRight = true)
            {
                transform.position = new Vector3(transform.position.x + 200 * Time.deltaTime, transform.position.y, transform.position.z);
            }

            if (transform.position.x > 1000)
            {
                transform.position = new Vector3(0f, transform.position.y, transform.position.z);

            }
        }

        void OnMouseDown()
        {
            Debug.Log("Hello World");
        }

    }







}
