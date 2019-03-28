using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBoneRotate : MonoBehaviour
{
    public int rotations = 30;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotations*Time.deltaTime);
    }
}
