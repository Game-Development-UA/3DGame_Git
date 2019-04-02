using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizonatal_mvmt;
    float vertical_mvmt;
    public float jump;
    public float speed;
    public float RunSpeed;
    public Rigidbody charac;
    float timeLeft = 3.0f; // Change for longer sprint
    public float countdown = 0; //Timer
    public int score = 0;
    public Projectile projectilePrefab;
    public int maxProjectiles;
    public List<Projectile> projectiles = new List<Projectile>();


    // Start is called before the first frame update
    void Start()
    {
        //score = Projectile.counter;
    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;
        
        if (countdown >= 180) //make go down
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
        }

        //move
        horizonatal_mvmt = Input.GetAxis("Horizontal");
        vertical_mvmt = Input.GetAxis("Vertical");
        charac.velocity = new Vector3(speed * horizonatal_mvmt, charac.velocity.y, speed * vertical_mvmt);

        Jump();
        Sprint();
    }

    public void Sprint() { 
        if (Input.GetButtonDown("Sprint"))
        {
            timeLeft = 3.0f;
            speed += RunSpeed;
            charac.velocity = new Vector3(speed * horizonatal_mvmt, charac.velocity.y, vertical_mvmt * speed);
        }
        //Timer for Sprint
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0 && timeLeft >-0.01)
        {
            speed -= RunSpeed;
            charac.velocity = new Vector3(speed * horizonatal_mvmt, charac.velocity.y, vertical_mvmt * speed);
    
        }
        
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            charac.AddForce(new Vector3(0f, jump * Time.deltaTime, 0f), ForceMode.Impulse);
        }
    }
    public void ProjectileDestroyed(Projectile projectileThatWasDestroyed)
    {
        projectiles.Remove(projectileThatWasDestroyed);
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), "Time left:  " + countdown);
        //GUI.Label(new Rect(100, 0, 100, 50), "Score:  " + counter);

    }

}
