using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

	Collider2D box;

	// Use this for initialization
	void Start () {
	
	box = transform.parent.collider2D;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			col.transform.parent = transform;
			rigidbody2D.isKinematic=false;
			box.enabled = false;
		}
	}
	
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			col.transform.parent = null;
		}
	}
	
}
