using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public Rigidbody rbody;
	public float speed;
	public float lifetime;
    //public AudioClip bark;

	public SimpleController playerOwner;

	float timer;

    void Start()
    {
        //GetComponent<AudioSource>().playOnAwake = false;
        //GetComponent<AudioSource>().clip = bark;
    }

    void Update() {
		timer += Time.deltaTime;

		if( timer > lifetime ) {
			playerOwner.ProjectileDestroyed( this );
			Destroy( this.gameObject );
		}
	}

	void FixedUpdate() {
		rbody.velocity = new Vector2( speed, 0f );
	}

	void OnTriggerEnter( Collider col ) {
		Destroyable destroyable = col.GetComponent<Destroyable>();

		if( destroyable ) {
            //GetComponent<AudioSource>().Play();
            Destroy( destroyable.gameObject );
		}

		playerOwner.ProjectileDestroyed( this );
		Destroy( this.gameObject );
	}
}
