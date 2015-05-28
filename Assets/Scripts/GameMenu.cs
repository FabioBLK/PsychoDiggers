using UnityEngine;
using System.Collections;


public class GameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void BotaoStart(){
		PlayerPrefs.SetInt("CheckPoint",0);
		Application.LoadLevel ("scene_fase02");
		PlayerPrefs.SetInt ("ThisScore", 0);



	}

	public void BotaoQuit(){
		Application.Quit ();
	}
}
