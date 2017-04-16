using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour {
    public float maxDistance = 1;

    private GameObject topMount;
    private GameObject bottomMount;
    private Collider ammoCollider;

    private Transform firstController;
    private Transform secondController;

    public void AttachController(Transform controller)
    {
        if (!firstController)
        {
            firstController = controller;
            //Physics.IgnoreCollision(ammoCollider, controller.GetComponent<BoxCollider>());
            controller.tag = "AttachedController";
            topMount.GetComponent<Rigidbody>().isKinematic = true;
            transform.localEulerAngles = new Vector3(0f, 0f, -90f);
        } else if (!secondController)
        {
            secondController = controller;
            //Physics.IgnoreCollision(ammoCollider, controller.GetComponent<BoxCollider>());
            controller.tag = "AttachedController";
            bottomMount.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

	// Use this for initialization
	void Start () {
		topMount = transform.FindChild("TopMount").gameObject;
        bottomMount = transform.FindChild("BottomMount").gameObject;
        ammoCollider = transform.GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (firstController)
        {
            float dist = Vector3.Magnitude(firstController.position - transform.position);
            if (dist > maxDistance) { dist = maxDistance; }
            float interpol = maxDistance - dist;
            transform.position = firstController.position;
            //topMount.transform.position = Vector3.Lerp(topMount.transform.position, firstController.position, interpol);
            //Debug.Log("Top to : " + firstController.position);
            //topMount.transform.position = firstController.position;
        }
        if (secondController)
        {
            float dist = Vector3.Magnitude(secondController.position - transform.position);
            if (dist > maxDistance) { dist = maxDistance; }
            float interpol = maxDistance - dist;
            //bottomMount.transform.position = Vector3.Lerp(bottomMount.transform.position, secondController.position, interpol);
            //Debug.Log("Top to : " + secondController.position);
            //bottomMount.transform.position = secondController.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            Debug.Log("Attaching");
            AttachController(other.gameObject.transform);
        } else if (other.CompareTag("Breech"))
        {
            if (other.transform.parent.GetComponent<GunController>().reloadGun())
            {
                if (firstController) { firstController.tag = "Controller"; }
                if (secondController) { secondController.tag = "Controller"; }
                Destroy(gameObject);
            }
        }
    }
}
