using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityStandardAssets.ImageEffects;


public class GameManager : MonoBehaviour {

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

    public GameObject CheckPoint;
    public GameObject Player;

    public GameObject RedTint;

	// public variables
	public int score=0;

	public bool canBeatLevel = false;
	public int beatLevelScore=0;

	public float startTime=5.0f;
	
	public Text mainScoreDisplay;
	public Text mainTimerDisplay;

	public GameObject gameOverScoreOutline;

	public AudioSource musicAudioSource;

	public bool gameIsOver = false;

	public GameObject playAgainButtons;
	public string playAgainLevelToLoad;

	public GameObject nextLevelButtons;
	public string nextLevelToLoad;

    public float CameraShakeDuration = 0.5f;
    public float CameraShakeMagnitude = 0.1f;

	private float currentTime;
    public Camera MainCamera;

	// setup the game
	void Start () {

		// set the current time to the startTime specified
		currentTime = startTime;

		// get a reference to the GameManager component for use by other scripts
		if (gm == null) 
			gm = this.gameObject.GetComponent<GameManager>();

		// init scoreboard to 0
		mainScoreDisplay.text = "0";

		// inactivate the gameOverScoreOutline gameObject, if it is set
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (false);

		// inactivate the playAgainButtons gameObject, if it is set
		if (playAgainButtons)
			playAgainButtons.SetActive (false);

		// inactivate the nextLevelButtons gameObject, if it is set
		if (nextLevelButtons)
			nextLevelButtons.SetActive (false);
	}

	// this is the main game event loop
	void Update () {
		if (!gameIsOver) {
			if (canBeatLevel && (score >= beatLevelScore)) {  // check to see if beat game
				BeatLevel ();
			} else if (currentTime < 0) { // check to see if timer has run out
				EndGame ();
			} else { // game playing state, so update the timer
				currentTime -= Time.deltaTime;
				mainTimerDisplay.text = currentTime.ToString ("0.00");				
			}
		}
	}

	void EndGame() {
		// game is over
		gameIsOver = true;

		// repurpose the timer to display a message to the player
		mainTimerDisplay.text = "GAME OVER";

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (true);
	
		// activate the playAgainButtons gameObject, if it is set 
		if (playAgainButtons)
			playAgainButtons.SetActive (true);

		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}
	
	void BeatLevel() {
		// game is over
		gameIsOver = true;

		// repurpose the timer to display a message to the player
		mainTimerDisplay.text = "LEVEL COMPLETE";

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (true);

		// activate the nextLevelButtons gameObject, if it is set 
		if (nextLevelButtons)
			nextLevelButtons.SetActive (true);
		
		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}

	// public function that can be called to update the score or time
	public void targetHit (int scoreAmount, float timeAmount)
	{
		// increase the score by the scoreAmount and update the text UI
		score += scoreAmount;
		mainScoreDisplay.text = score.ToString ();
		
		// increase the time by the timeAmount
		currentTime += timeAmount;
		
		// don't let it go negative
		if (currentTime < 0)
			currentTime = 0.0f;

		// update the text UI
		mainTimerDisplay.text = currentTime.ToString ("0.00");
	}

	// public function that can be called to restart the game
	public void RestartGame ()
	{
		// we are just loading a scene (or reloading this scene)
		// which is an easy way to restart the level
		//Application.LoadLevel (playAgainLevelToLoad);
        SceneManager.LoadScene(playAgainLevelToLoad);
	}

	// public function that can be called to go to the next level of the game
	public void NextLevel ()
	{
		// we are just loading the specified next level (scene)
		//Application.LoadLevel (nextLevelToLoad);
        SceneManager.LoadScene(nextLevelToLoad);
	}


    public void PlayShake()
    {
        //StopAllCoroutines();
        StartCoroutine("Shake");
    }

    IEnumerator Shake()
    {

        float elapsed = 0.0f;

        Vector3 originalCamPos = MainCamera.transform.position;

        while (elapsed < CameraShakeDuration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / CameraShakeDuration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map noise to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            //float x = 1.0f * Mathf.PerlinNoise(Time.time * 1.0f, 0.0F);
            float y = Random.value * 2.0f - 1.0f;
            //float y = 1.0f * Mathf.PerlinNoise(Time.time * 1.0f, 0.0F);
            x *= CameraShakeMagnitude * damper;
            y *= CameraShakeMagnitude * damper;

            MainCamera.transform.position = new Vector3(x + originalCamPos.x, y + originalCamPos.y, originalCamPos.z);

            yield return null;
        }

        MainCamera.transform.position = originalCamPos;
    }

    public void PaintItRed()
    {
        MainCamera.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>().enabled = true;
        RedTint.SetActive(true);
    }


    public void PauseMusic()
    {
        musicAudioSource.Pause();
    }

    public void SetCheckpoint(GameObject CheckPoint)
    {
        this.CheckPoint = CheckPoint;
    }

    public void RespawnPlayer()
    {
        Player.transform.position = CheckPoint.transform.position;
    }
}
