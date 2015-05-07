using UnityEngine;
using System.Collections;

public class UpDownPlatform : MonoBehaviour {
	

	bool position= true;
	float posYOne,posYTwo;
	public float distancia,velocidade,offSet;
	
	// Use this for initialization
	void Start () {
	
	posYOne = transform.position.y+distancia;
	posYTwo = transform.position.y-distancia;
		transform.position = new Vector3(transform.position.x,offSet,transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {

		
		if (position==true){
			//rigidbody2D.velocity = new Vector2(0,velocidade);
			transform.Translate(new Vector3(0,velocidade*Time.deltaTime,0));
		}
		
		if (position==false){
			//rigidbody2D.velocity = new Vector2(0,-velocidade);
			transform.Translate(new Vector3(0,-velocidade*Time.deltaTime,0));
		}
		
		if (transform.position.y > posYOne){
			position=false;
		}
		
		if (transform.position.y < posYTwo){
			position=true;
		}
		
		
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
