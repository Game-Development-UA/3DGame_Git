using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBoneRotate : MonoBehaviour
{
    public int rotations = 30;
    // Update is called once per frame
    public float x;
    public float y;
    public float z;
    public Vector3 pos;

    public void Start()
    {
        //Random Spawn
        x = UnityEngine.Random.Range(-200, 200);
        y = 0;
        z = UnityEngine.Random.Range(-100, 100);
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    void Update()
    {
        transform.Rotate(0f, 0f, rotations*Time.deltaTime);        
    }
}
