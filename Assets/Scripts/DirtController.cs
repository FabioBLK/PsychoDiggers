using UnityEngine;
using System.Collections;

public class DirtController : MonoBehaviour {

	public float countdown = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//Timer
		countdown -= Time.deltaTime;
		
		//Destroy o objeto se o timer for menor do que 0 
		if (countdown < 2.0f){
			Destroy(gameObject);
		}
	
	}
	
	
}
