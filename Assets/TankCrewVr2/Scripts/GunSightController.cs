using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSightController : MonoBehaviour {
    public Transform sightCamTrans;
    public Transform sight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(sightCamTrans.localPosition.z, sightCamTrans.localPosition.y, sightCamTrans.localPosition.x) * 10;
        transform.localEulerAngles = new Vector3(sightCamTrans.localRotation.z, sightCamTrans.localRotation.y, sightCamTrans.localRotation.x);
        /*if (sightCamTrans.localPosition.x > 0)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        }*/
        //sight.eulerAngles = Vector3.zero;
	}
}
