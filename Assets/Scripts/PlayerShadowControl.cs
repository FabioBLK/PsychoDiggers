using UnityEngine;
using System.Collections;

public class PlayerShadowControl : MonoBehaviour {

	private GameObject playerShadow;
	private Vector3 positionPlayer;

	Digger1Controller digger1;
	Digger2Controller digger2;
	
	
	// Use this for initialization
	void Start () {
		ChangeToDigger1 ();	
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3 (playerShadow.transform.position.x,transform.position.y, transform.position.z);
		transform.localScale = playerShadow.transform.localScale;
		
	}
	
	public void ChangeToDigger1(){
		//Procura o Digger1Controller na cena e diz para a camera quem seguir.
		digger1 = FindObjectOfType<Digger1Controller>();
		playerShadow = digger1.gameObject;  
		
		                      
	}
	
	public void ChangeToDigger2(){
		//Procura o Digger2Controller na cena e diz para a camera quem seguir.
		digger2 = FindObjectOfType<Digger2Controller>();
		playerShadow = digger2.gameObject;
		
	}
}
