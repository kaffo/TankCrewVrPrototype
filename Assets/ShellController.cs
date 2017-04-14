using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour {
    public GameObject gun;
    public float shellSpeed = 500f;
    public float maxShellDistance = 500f;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = gun.transform.rotation;
        transform.position = gun.transform.TransformPoint(gun.transform.localPosition + new Vector3(3f, -0.2f, 0));
        rb.AddForce(gun.transform.right * shellSpeed, ForceMode.Impulse);
        //Debug.Log(barrel.transform.up * shellSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Magnitude(transform.position - gun.transform.position) > maxShellDistance)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate () {
        Vector3 fwd = transform.TransformDirection(Vector3.right);
        RaycastHit hit;
        Debug.DrawRay(transform.position, fwd, Color.blue);
        if (Physics.Raycast(transform.position, fwd, out hit, 1.0f))
        {
            //Debug.Log("Object Hit!");
            Destroy(hit.transform.gameObject);
        }
    }
}
