using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class Rotator : MonoBehaviour
    {
        float m_Angle;

        void Update()
        {
            this.transform.Rotate(0.3f, 0, 0, Space.Self);
        }
    }
}