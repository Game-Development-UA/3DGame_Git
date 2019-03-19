using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizonatal_mvmt;
    float vertical_mvmt;
    public float jump;
    public float speed;
    public Rigidbody charac;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizonatal_mvmt = Input.GetAxis("Horizontal");
        vertical_mvmt = Input.GetAxis("Vertical");
        charac.velocity = new Vector2(speed * horizonatal_mvmt, charac.velocity.y);
    }
}
