using UnityEngine;
using System.Collections;

public class BrowserHelper : MonoBehaviour {

	//Giveup Page
    public void OpenPage1()
    {
        Application.OpenURL("http://brainfreezestudios.com/tagged/games");
    }

    //Fight Page
    public void OpenPage2()
    {
        Application.OpenURL("http://brainfreezestudios.com");
    }
}
