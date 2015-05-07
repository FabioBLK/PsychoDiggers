using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

public static int scorePlayer; // declara a variavel para pontos

Text scoreText;

	void Awake(){
	scoreText = GetComponent<Text>();
	scorePlayer = 0;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	scoreText.text = "Pontos: " + scorePlayer.ToString ();
	
	}
}
