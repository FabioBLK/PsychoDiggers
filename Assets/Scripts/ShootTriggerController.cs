using UnityEngine;
using System.Collections;

public class ShootTriggerController : MonoBehaviour {
	
	int skullCounter;
	public GameObject skullShot;
	float xPos;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		xPos = transform.parent.localScale.x;
	}
	
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag=="Player" && transform.childCount<1){
			InvokeRepeating ("Fire",0.00001f,1.5f);
		}
	}
	
	void Fire(){
		GameObject skull = Instantiate(skullShot,transform.position,Quaternion.identity)as GameObject;
		skull.rigidbody2D.AddForce(new Vector2(xPos*250,100));
		skull.transform.parent = transform;
		//skullCounter++;
	}
		
}
