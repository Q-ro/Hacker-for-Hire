using UnityEngine;
using System.Collections;
using UnityEngine.UI; // include UI namespace since references UI Buttons directly
using UnityEngine.EventSystems; // include EventSystems namespace so can set initial input for controller support
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    // references to Submenus
    public GameObject _MainMenu;
    public GameObject _HowToPlayMenu;
    public GameObject _CreditsMenu;

    // references to Button GameObjects
    public GameObject MenuDefaultButton;
    public GameObject HowToPlayDefaultButton;
    public GameObject CreditsDefaultButton;
    public GameObject QuitButton;

    void Awake()
    {
        // determine if Quit button should be shown
        displayQuitWhenAppropriate();

        // Show the proper menu
        ShowMenu("MainMenu");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Show the proper menu
    public void ShowMenu(string name)
    {
        // turn all menus off
        _MainMenu.SetActive(false);
        _HowToPlayMenu.SetActive(false);
        _CreditsMenu.SetActive(false);

        // turn on desired menu and set default selected button for controller input
        switch (name)
        {
            case "MainMenu":
                _MainMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(MenuDefaultButton);
                break;
            case "HowToPlay":
                _HowToPlayMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(HowToPlayDefaultButton);
                break;
            case "Credits":
                _CreditsMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(CreditsDefaultButton);
                break;

        }
    }

    // determine if the QUIT button should be present based on what platform the game is running on
    void displayQuitWhenAppropriate()
    {
        switch (Application.platform)
        {
            // platforms that should have quit button
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.OSXPlayer:
            case RuntimePlatform.LinuxPlayer:
                QuitButton.SetActive(true);
                break;

            // platforms that should not have quit button
            // note: included just for demonstration purposed since
            // default will cover all of these. 
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.OSXWebPlayer:
            case RuntimePlatform.WindowsWebPlayer:
            case RuntimePlatform.WebGLPlayer:
                QuitButton.SetActive(false);
                break;

            // all other platforms default to no quit button
            default:
                QuitButton.SetActive(false);
                break;
        }
    }

    public void loadLevel(string levelToLoad)
    {
        // load the specified level
        SceneManager.LoadScene(levelToLoad);
        //Application.LoadLevel (leveltoLoad);

    }

    // quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
