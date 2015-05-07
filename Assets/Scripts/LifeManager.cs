using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeManager : MonoBehaviour {
public static int playerLives = 2; // jogador tem 3 vidas, interpretar como array 0 1 2
public Sprite[] imageLives = new Sprite[3];
public Image imageSource;
float timeCounter = 0;

	// Use this for initialization
	void Awake () {
	imageSource = GetComponent<Image>();

	}
	
	
	
	// Update is called once per frame
	void Update () {
	
	
	
	if(playerLives >= 0 ){
	imageSource.sprite = imageLives[playerLives];
		} else if(playerLives < 0)
		{
			timeCounter+=Time.deltaTime;
			if (timeCounter>2.0f){
				ReloadLevel();
			}
		}
	}
	
	void ReloadLevel(){
		Application.LoadLevel (Application.loadedLevel);
		playerLives = 2;
	}
} 
