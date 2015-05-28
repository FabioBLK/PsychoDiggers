using UnityEngine;
using System.Collections;

public class StageFinish : MonoBehaviour {
	float timer;
	bool finish = false;
	// Use this for initialization
	void Start () {
		print("loaded level " + Application.loadedLevel);
		print("level count " + Application.levelCount);
	}
	
	// Update is called once per frame
	void Update () {
		if (finish==true){
			timer+=Time.deltaTime;
		}
		if (timer>5){
			if (Application.loadedLevel<Application.levelCount-1){
				Application.LoadLevel (Application.loadedLevel+1);
			}
			if (Application.loadedLevel == Application.levelCount-1){
				Application.LoadLevel (0);
			}
		
		}
	}
	
	
	void OnTriggerEnter2D(Collider2D col){
		
		
		if (col.gameObject.name == "DiggerOne(Clone)" || col.gameObject.name == "DiggerOne"){
			print ("Chegou aqui no 1");
			Animator anim = col.GetComponent<Animator>();
			anim.SetBool ("Victory",true);
			Digger1Controller digger = col.GetComponent<Digger1Controller>();
			digger.PauseDiggerFinish(-10);
			finish = true;
			PlayerPrefs.SetInt("CheckPoint",0);
			PlayerPrefs.SetInt("ThisScore",ScoreManager.scorePlayer);
		}
		
		
		if (col.gameObject.name == "DiggerTwo(Clone)" || col.gameObject.name == "DiggerTwo"){
			print ("Chegou aqui no 2");
			Animator anim = col.GetComponent<Animator>();
			anim.SetBool ("Victory",true);
			Digger2Controller digger = col.GetComponent<Digger2Controller>();
			digger.PauseDiggerFinish(-10);
			finish=true;
			PlayerPrefs.SetInt("CheckPoint",0);
			PlayerPrefs.SetInt("ThisScore",ScoreManager.scorePlayer);
		}
	}
	
}
