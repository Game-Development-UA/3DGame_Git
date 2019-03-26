using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform lookAt;
    public Transform cTransform;
    private Camera Cam;
    private float dist = 5.0f;
    private float PosX = 0.0f;
    private float PosY = 0.0f; 

    // Start is called before the first frame update
    private void Start()
    {
        cTransform = transform;
        Cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 dir = new Vector3(0, 0, -dist);
        Quaternion rot = Quaternion.Euler(PosX, PosY, 0);
        cTransform.position = lookAt.position + rot * dir;
    }
}
