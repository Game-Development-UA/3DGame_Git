using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    float horizonatal_mvmt;
    float vertical_mvmt;
    public float jump;
    public float JumpTime = 0f;
    public float speed;
    [SerializeField] private float RunSpeed;
    public Rigidbody charac;
    float timeLeft = 3.0f; // Change for longer sprint
    public float countdown = 0; //Timer
    public int score = 0;
    public Projectile projectilePrefab;
    public int maxProjectiles;
    public List<Projectile> projectiles = new List<Projectile>();
    private Vector3 rot;
    public List<Dog_Abilities> abilities;


    // Start is called before the first frame update
    void Start()
    {
        //score = Projectile.counter;
    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;
        if (countdown >= 180)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
        }
        move();
        Jump();
        if (Input.GetButtonDown("Sprint"))
            StartCoroutine(Sprint(3.0f));
    }
    public void move()
    {
        horizonatal_mvmt = Input.GetAxis("Horizontal");
        vertical_mvmt = Input.GetAxis("Vertical");
        charac.velocity = new Vector3(horizonatal_mvmt*speed, charac.velocity.y, vertical_mvmt*speed);

        //Character rotaion 

        if (horizonatal_mvmt > 0)
        {
            rot.y = 0f;
        }
        if (horizonatal_mvmt < 0)
        {
            rot.y = 180f;
        }
        if (vertical_mvmt > 0)
        {
            rot.y = -90f;
        }
        if (vertical_mvmt < 0)
        {
            rot.y = 90f;
        }
        transform.eulerAngles = rot;
    }

    IEnumerator Sprint(float duration)
    {

        float i = 0;
        float rate = 1 / duration;
        while (i < duration)
        {
            speed = RunSpeed;
            charac.velocity = new Vector3(speed * horizonatal_mvmt, charac.velocity.y, vertical_mvmt * speed);
            i += Time.deltaTime *duration;
            yield return speed = 3;
        }
        
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && Time.time > JumpTime)
        {
            charac.AddForce(new Vector3(0f, jump * Time.deltaTime, 0f), ForceMode.Impulse);
            JumpTime = Time.time + 1.5f; // change to increase or deacrease delay of jump
        }
    }
    public void ProjectileDestroyed(Projectile projectileThatWasDestroyed)
    {
        //score += 1;
        projectiles.Remove(projectileThatWasDestroyed);
    }
    public void ProjectileDestroyedTime(Projectile projectileThatWasDestroyed)
    {
        projectiles.Remove(projectileThatWasDestroyed);
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), "Time left:  " + countdown);
        //GUI.Label(new Rect(100, 0, 100, 50), "Score:  " + counter);

    }

}
