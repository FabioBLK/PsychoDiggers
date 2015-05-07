using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {
	
	
	
	public float velocityWeapon;
	private float direction;
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			other.GetComponent<ControllerNecro>().WeaponHit(true);
			Destroy (gameObject);
			//Debug.Log ("Acertou inimigo");
		}
		if (other.gameObject.tag == "Dirty")
		{
			Destroy (gameObject);
		}
		
	}
	
	
	// Use this for initialization
	void Start () {
		GameObject weaponDirection = GameObject.FindGameObjectWithTag("Player");
		direction = weaponDirection.transform.localScale.x;
		this.rigidbody2D.AddForce(new Vector2(100 * velocityWeapon * direction  ,0));
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	
	
	
}
