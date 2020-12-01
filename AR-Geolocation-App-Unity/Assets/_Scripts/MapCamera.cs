using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void LateUpdate()
	{
		Quaternion desiredRotation = transform.rotation;

		DetectTouchMovement.Calculate();

		if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)
		{ // rotate
			Vector3 rotationDeg = Vector3.zero;
			rotationDeg.z = -DetectTouchMovement.turnAngleDelta;
			desiredRotation *= Quaternion.Euler(rotationDeg);
		}

		// not so sure those will work:
		transform.rotation = desiredRotation;
	}
}
