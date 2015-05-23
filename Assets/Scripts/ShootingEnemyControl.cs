using UnityEngine;
using System.Collections;

public class ShootingEnemyControl : MonoBehaviour {
	
	Animator necroAnim;
	GameObject playerPosition;
	float playerXPos,necroXPos,xPos;
	public int health=60;
	

	
	//Transform shootTrigger;
	
	// Use this for initialization
	void Start () {
		necroAnim = GetComponent<Animator>();
		playerPosition = GameObject.Find ("PlayerShadow");
		//shootTrigger = transform.FindChild ("ShootTrigger");
	}
	
	// Update is called once per frame
	void Update () {
		
		
		FaceDirection ();
		
		if (health<0){
			Destroy (gameObject);
		}	
		
	}

	void FaceDirection ()
	{
		necroXPos = transform.position.x;
		playerXPos = playerPosition.transform.position.x;
		if (necroXPos <= playerXPos) {
			xPos = 1;
		}
		if (necroXPos > playerXPos) {
			xPos = -1;
		}
		transform.localScale = new Vector3 (xPos, 1, 1);
	}
	
	/*	
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag=="Player" && skullCounter<1){
			GameObject skull = Instantiate(skullShot,transform.position,Quaternion.identity)as GameObject;
			skull.rigidbody2D.AddForce(new Vector2(xPos*250,100));
			skullCounter++;
		}
	}
	*/
	
	void OnTriggerEnter2D(Collider2D col){
		//print (col.gameObject.tag);
		if (col.gameObject.tag=="Shovel"){
			health -= Controller_Shovel.weaponDamage;
			//WeaponHit(true);
			//gameObject.GetComponent<EnemyHealth>().TakeDamage (Controller_Shovel.weaponDamage);
		}
		if (col.gameObject.tag == "Stomp"){
			health -= Digger2StompControl.stompDamage;
			//WeaponHit(true);
			//gameObject.GetComponent<EnemyHealth>().TakeDamage (Digger2StompControl.stompDamage);
		}
	}
	
	
	
}
