﻿using UnityEngine;
using System.Collections;

public class CheckPointController : MonoBehaviour {

	public int checkPointNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player"){
			PlayerPrefs.SetInt("CheckPoint",checkPointNumber);
			print (PlayerPrefs.GetInt("CheckPoint"));
		}
	}
	
}
