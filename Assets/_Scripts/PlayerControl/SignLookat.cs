using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignLookat : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform);
        transform.rotation = cam.transform.rotation;
    }
}
