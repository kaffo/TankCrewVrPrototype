using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    public float maxAngle = 35f;
    public float minAngle = -5f;
    public float reloadTime = 5.0f;
    public GameObject shellPrefab;

    private GameObject barrel;
    private GameObject breech;
    private AudioSource reloadAudio;
    private AudioSource fireAudio;
    private bool reloaded = false;
    private float timePassed = 0f;

	// Use this for initialization
	void Start () {
        breech = transform.FindChild("Breech").gameObject;
        barrel = transform.FindChild("Barrel").gameObject;

        fireAudio = transform.GetComponent<AudioSource>();
        reloadAudio = breech.transform.GetComponent<AudioSource>();

        if (breech == null || barrel == null || shellPrefab == null)
        {
            Debug.Log("Cannot find all gun GameObjects!");
        }
    }

    private void Update()
    {
        if (timePassed < reloadTime)
        {
            timePassed += Time.deltaTime;
        } else if (!reloaded)
        {
            Debug.Log("Reload");
            reloaded = true;
            reloadAudio.Play();
        }
    }

    public float currentAngle
    {
        get
        {
            if (transform.localEulerAngles.z > 180)
            {
                return transform.localEulerAngles.z - 360;
            } else
            {
                return transform.localEulerAngles.z;
            }
        }
    }

    public void adjustGun(float delta)
    {
        float newAngle = currentAngle + delta;
        //Debug.Log("delta: " + delta + " newangle: " + newAngle);
        if (delta > 0 && newAngle < maxAngle)
        {
            transform.localEulerAngles += new Vector3(0f, 0f, delta);
        } else if (delta < 0 && newAngle > minAngle)
        {
            transform.localEulerAngles += new Vector3(0f, 0f, delta);
        }
    }

    public void fireGun()
    {
        if (reloaded)
        {
            Debug.Log("Firing");
            timePassed = 0f;
            reloaded = false;
            GameObject shell = Instantiate(shellPrefab);
            shell.GetComponent<ShellController>().gun = gameObject;
            fireAudio.Play();
        }
    }
}
