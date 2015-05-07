using UnityEngine;
using System.Collections;

public class DetectionMessage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag=="Shovel"){
			
			Debug.Log ("Eh pah");
		}
		if (col.gameObject.tag == "Stomp"){
			
			Debug.Log ("Eh Pedra");
		}
		
		
		Debug.Log ("Entrou no Circulo");
	}
}
