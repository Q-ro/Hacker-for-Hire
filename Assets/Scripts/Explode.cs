using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour 
{

    // A projectile to be spawned when an explosive is hit
    public GameObject projectile;
    public int projectileSpeed = 50;
    private GameObject projectileSpawner;

	// Use this for initialization
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision newCollision)
    {

        if (GameManager.gm)
        {
            // Make sure the game is still going before spawning projectiles, otherwise the game will crash
            if (GameManager.gm.gameIsOver)
            {
                return;
            }
            else
            {

                if (newCollision.gameObject.tag == "Projectile" || newCollision.gameObject.tag == "BombProjectile")
                {

                    if (projectile)
                    {
                        //Create a GameObject to foster the bullets to be spawned
                        projectileSpawner = new GameObject("ProjectileSpawner");
                    }

                    if (projectile && this.tag == "Explosive")
                    {
                        //Debug.Log("BOOOOM");

                        // Randomly generate 120 bullets with random directions and a speed of 50
                        for (int i = 0; i < 120; i++)
                        {
                            SpawnProjectiles(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)), Random.Range(-1, 2) * projectileSpeed);
                        }

                    }
                }

                // Clean after ourself
                // Destroy the projectile holder after 1 second
                Destroy(projectileSpawner, 1);
            }
                
        }
        
    }
    void SpawnProjectiles(Vector3 direction, int force)
    {
        GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;

        // Keep the hierarchy clean
        if (projectileSpawner)
        {
            newProjectile.transform.SetParent(projectileSpawner.transform);
        }

        // if the projectile does not have a rigidbody component, add one
        if (!newProjectile.GetComponent<Rigidbody>())
        {
            newProjectile.AddComponent<Rigidbody>();
        }

        // Apply force to the newProjectile's Rigidbody component if it has one
        newProjectile.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.VelocityChange);
    }

}
