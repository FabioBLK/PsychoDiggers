using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {
	public GameObject pauseMenuCanvas;



	void Awake(){
		Time.timeScale = 1;
	}

	public void ResumeButton(){
		Time.timeScale = 1;
		pauseMenuCanvas.SetActive(false);
	}
	
	public void ReiniciaButton(){
		PlayerPrefs.SetInt("CheckPoint",0);
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void QuitMenuButton(){
		Application.LoadLevel("MenuInicial");
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(Time.timeScale == 0){
				// Despausar
				Time.timeScale = 1;
				pauseMenuCanvas.SetActive(false);
			}else{
			// Pausar
			Time.timeScale = 0;
			pauseMenuCanvas.SetActive(true);
			}
		}
		
	}
}
