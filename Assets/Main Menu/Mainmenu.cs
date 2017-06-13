using UnityEngine;
using System.Collections;

public class Mainmenu : MonoBehaviour {

public GameObject quiz;
public void Start()
{
    Screen.orientation = ScreenOrientation.LandscapeLeft;

}
	public void QuitGame() {
		Application.Quit ();
	}

	public void StarGame() {
		Application.LoadLevel ("2");
	}

}
