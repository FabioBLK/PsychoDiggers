using UnityEngine;
using System.Collections;

public class Digger2StompControl : MonoBehaviour {

	Digger2Controller stomp;
	public static int stompDamage = 100;

	// Use this for initialization
	void Start () {
		
		stomp = FindObjectOfType<Digger2Controller>();
		
	}
	
	// Update is called once per frame
	void Update () {
		//print (stomp);
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag=="Enemy"){
			
			stomp.Stomp();		
		}
	}
	
}
