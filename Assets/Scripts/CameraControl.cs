using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	private GameObject cameraPlayer;
	private Vector3 positionPlayer;
	private Vector3 lastPosition;
	
	Digger1Controller digger1;
	Digger2Controller digger2;
	

	// Use this for initialization
	void Start () {
		ChangeToDigger1 ();	
		
		//camera.aspect=(1.8f);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
			transform.position = new Vector3 (cameraPlayer.transform.position.x,cameraPlayer.transform.position.y+2, transform.position.z);
	
		if(Input.GetKey (KeyCode.DownArrow)) {

			lastPosition = new Vector3(transform.position.x,transform.position.y,0);

			transform.position = new Vector3( cameraPlayer.transform.position.x, Mathf.Lerp (cameraPlayer.transform.position.y,cameraPlayer.transform.position.y * -1f,Time.time), transform.position.z);


		}


	}



	
	public void ChangeToDigger1(){
		//Procura o Digger1Controller na cena e diz para a camera quem seguir.
		digger1 = FindObjectOfType<Digger1Controller>();	
		cameraPlayer = digger1.gameObject;                          
	}
	
	public void ChangeToDigger2(){
		//Procura o Digger2Controller na cena e diz para a camera quem seguir.
		digger2 = FindObjectOfType<Digger2Controller>();
		cameraPlayer = digger2.gameObject;
		
	}
	
}
