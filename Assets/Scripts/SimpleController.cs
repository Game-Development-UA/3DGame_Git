using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
	public int maxProjectiles;

	public Transform projectileSpawnLocation;

	public Projectile projectilePrefab;

	public List<Projectile> projectiles = new List<Projectile>();
    //public Transform dogPosition;

    //public int counter = 0;


    void Update() {
        /*if (counter == 5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinPage");
        }*/

        if ( Input.GetButtonDown( "Fire1" ) ) {
			if( projectiles.Count < maxProjectiles ) {
				Projectile newProjectile = Instantiate<Projectile>( projectilePrefab);
				newProjectile.transform.position = projectileSpawnLocation.position;
				newProjectile.transform.forward = projectileSpawnLocation.right;

				newProjectile.playerOwner = this;

				projectiles.Add( newProjectile );
			} 
		}

	}


	public void ProjectileDestroyed( Projectile projectileThatWasDestroyed ) {
        //counter += 1;
        projectiles.Remove( projectileThatWasDestroyed );
	}

    /*void OnGUI()
    {
        GUI.Label(new Rect(100, 0, 100, 50), "Score:  " + counter);

    }*/
}
