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
    public int counter = 0;
    //public Text scoreText;
    //public AudioClip bark;

    public SimpleController playerOwner;

	float timer;

    void Start()
    {
        //scoreText = GetComponent<Text>();
    }

    void Update() {
        timer += Time.deltaTime;
        //scoreText.text = counter.ToString();
        if ( timer > lifetime ) {
			playerOwner.ProjectileDestroyed( this );
			Destroy( this.gameObject );
		}
        if (counter == 5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinPage");
        }
    }

	void FixedUpdate() {
		rbody.velocity = new Vector2( speed, 0f );
	}

	void OnTriggerEnter( Collider col ) {
		Destroyable destroyable = col.GetComponent<Destroyable>();

		if( destroyable ) {
            //Debug.Log(counter);
            //GetComponent<AudioSource>().Play();
            Destroy( destroyable.gameObject );
		}
        counter += 1;
        playerOwner.ProjectileDestroyed( this );
		Destroy( this.gameObject );
	}

}
