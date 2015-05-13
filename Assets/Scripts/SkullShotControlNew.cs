using UnityEngine;
using System.Collections;

public class SkullShotControlNew : MonoBehaviour {

	float timer;
	float fireCounter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;
		
		if (timer>3f){
			Destroy (gameObject);
		}
	
	}
	
	void OnDestroy(){
		
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag=="Player"){
			gameObject.collider2D.enabled=false;
		}
	}
}
