using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
	public int maxProjectiles;

	public Transform projectileSpawnLocation;

	public Projectile projectilePrefab;

	public List<Projectile> projectiles = new List<Projectile>();

	void Update() {

		if( Input.GetButtonDown( "Fire1" ) ) {
			if( projectiles.Count < maxProjectiles ) {
				Projectile newProjectile = Instantiate<Projectile>( projectilePrefab );
				newProjectile.transform.position = projectileSpawnLocation.position;
				newProjectile.playerOwner = this;

				projectiles.Add( newProjectile );
			} 
		}
	}


	public void ProjectileDestroyed( Projectile projectileThatWasDestroyed ) {
		projectiles.Remove( projectileThatWasDestroyed );
	}
}
