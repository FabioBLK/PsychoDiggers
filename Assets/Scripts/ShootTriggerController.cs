using UnityEngine;
using System.Collections;

public class ShootTriggerController : MonoBehaviour {
	
	int skullCounter;
	public GameObject skullShot;
	float xPos;
	float timer;
	public float timeRate;
	
	// Use this for initialization
	void Start () {
		timer = timeRate;
	}
	
	// Update is called once per frame
	void Update () {
		xPos = transform.parent.localScale.x;
		timer += Time.deltaTime;
	}
	
	void OnTriggerStay2D(Collider2D col){
		//if (col.gameObject.tag=="Player" && transform.childCount<1){
		if (col.gameObject.tag=="Player" && timer>timeRate){
			//InvokeRepeating ("Fire",0.00001f,1.5f);
			Fire ();
			timer=0;
		}
	}
	
	void Fire(){
		GameObject skull = Instantiate(skullShot,transform.position,Quaternion.identity)as GameObject;
		skull.rigidbody2D.AddForce(new Vector2(xPos*250,100));
		//skull.transform.parent = transform;
		//skullCounter++;
	}
		
}
