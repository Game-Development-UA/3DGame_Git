﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizonatal_mvmt;
    float vertical_mvmt;
    public float jump;
    public float speed;
    public Rigidbody charac;
    public Projectiles projectilePrefab;
    public int maxProjectiles;
    public List<Projectiles> projectiles = new List<Projectiles>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Direct_Movement();
        Jump();
    }

    public void Direct_Movement()
    {
        horizonatal_mvmt = Input.GetAxis("Horizontal");
        vertical_mvmt = Input.GetAxis("Vertical");
        charac.velocity = new Vector3(speed * horizonatal_mvmt, charac.velocity.y, vertical_mvmt * speed);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            charac.AddForce(new Vector3(0f, jump * Time.deltaTime, 0f), ForceMode.Impulse);
        }
    }
    public void ProjectileDestroyed(Projectiles projectileThatWasDestroyed)
    {
        projectiles.Remove(projectileThatWasDestroyed);
    }
}
