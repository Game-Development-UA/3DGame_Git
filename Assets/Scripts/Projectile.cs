using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
	public Rigidbody rbody;
	public float speed;
	public float lifetime;
    public int counter;
    ///[SerializeField] private float dist;

    //public Text scoreText;
    //public AudioClip bark;

    public SimpleController playerOwner;

	float timer;

    void Start()
    {
    }

    void Update() {
        ///StartCoroutine(Distance(3.0f));
        timer += Time.deltaTime;
        //scoreText.text = counter.ToString();
        if ( timer > lifetime ) {
			playerOwner.ProjectileDestroyedTime( this );
			Destroy( this.gameObject );
		}
        /*if (counter == 5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinPage");
        }*/
    }
    ///IEnumerator Distance( float dist)
    ///{
       /// float i = 0;
        ///while (i > dist)
        ///{
           /// playerOwner.ProjectileDestroyedTime(this);
            ///Destroy(this.gameObject);
            ///i += Time.deltaTime;
            ///yield return 0;
        ///}
    ///}
        
	void FixedUpdate() {
		rbody.velocity = transform.forward * speed;
	}

	void OnTriggerEnter( Collider col ) {
		Destroyable destroyable = col.GetComponent<Destroyable>();

		if( destroyable ) {
            //Debug.Log(counter);
            //GetComponent<AudioSource>().Play();
            Destroy( destroyable.gameObject );
		}
        //counter += 1;
        playerOwner.ProjectileDestroyed( this );
		Destroy( this.gameObject );
	}

    /*void OnGUI()
    {
        GUI.Label(new Rect(100, 0, 100, 50), "Score:  " + counter);

    }*/

}
