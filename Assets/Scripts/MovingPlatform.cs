using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public float timer = 0;
	public float speed = 0;
	public float size = 0;
	
	//Transform child;
	
	// Use this for initialization
	void Start () {
		//child = GetComponentInChildren<Transform>();
		gameObject.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime*speed;
		
		float xPos = Mathf.Cos(timer)*size;
		float yPos = Mathf.Sin(timer)*size;
		
		transform.localPosition = new Vector3(xPos,yPos,0);
		
		
		//rigidbody2D.MovePosition(new Vector2(xPos,yPos));
		
		
		//transform.GetChild(0).rigidbody2D.transform.position = new Vector3(xPos, yPos, 0);
		
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
		
			col.transform.parent = transform;
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
