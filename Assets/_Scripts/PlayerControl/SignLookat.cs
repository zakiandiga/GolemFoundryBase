using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignLookat : MonoBehaviour
{
    Camera cam;
    SphereCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform);
        transform.rotation = cam.transform.rotation;
    }
}
