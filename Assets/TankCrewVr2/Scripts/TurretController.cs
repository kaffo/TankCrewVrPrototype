using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
    public float currentAngle
    {
        get
        {
            if (transform.localEulerAngles.y > 180)
            {
                return transform.localEulerAngles.y - 360;
            }
            else
            {
                return transform.localEulerAngles.y;
            }
        }
    }

    public void adjustTurret(float delta)
    {
        transform.localEulerAngles += new Vector3(0f, delta, 0f);
    }
}
