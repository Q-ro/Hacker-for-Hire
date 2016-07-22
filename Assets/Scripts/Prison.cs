using UnityEngine;
using System.Collections;

public class Prison : MonoBehaviour {

    public AudioClip FreeSFX;
    public AudioClip RumbleSFX;
    public int Score = 1000000;

    // explosion when hit?
    public GameObject explosionPrefab;

    bool _collided = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            if (!_collided)
            {

                _collided = true;

                if (explosionPrefab)
                {
                    // Instantiate an explosion effect at the gameObjects position and rotation
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                }

                GameManager.gm.targetHit(Score, 0);                

                //Playsound sound            
                this.GetComponent<AudioSource>().PlayOneShot(FreeSFX);

                Invoke("AfterFree",4);

            }
            
        }
    }

    void AfterFree()
    {
        GameManager.gm.PauseMusic();

        // Turn it all red
        GameManager.gm.PaintItRed();

        // shake cam
        GameManager.gm.PlayShake();

        this.GetComponent<AudioSource>().PlayOneShot(RumbleSFX);        

        //move to next scene
        Invoke("GoNextLevel", 3);
    }

    void GoNextLevel()
    {
        GameManager.gm.NextLevel();
    }

}
