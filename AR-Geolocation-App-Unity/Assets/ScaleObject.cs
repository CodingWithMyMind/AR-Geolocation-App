using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{ 
	void OnMouseDown() {
	Scale1.ScaleTransform = this.transform;
	}
}