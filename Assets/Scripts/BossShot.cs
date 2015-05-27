using UnityEngine;
using System.Collections;

public class BossShot : MonoBehaviour {

	public float velocityShovel;
	private float direction,timer;
	public float velocidadeGosma;
	Vector2 boxSizeRegular;
	BoxCollider2D boxSizeNow;
	int tipoTiro; // define o tipo de tiro : tiro reto ou tiro que cai no chao, randomico
	
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
			
		
		if (other.gameObject.tag == "Dirty")
		{
		//	Destroy (gameObject);
		}
		
		if (other.gameObject.tag == "Shovel")
		{
		//	Destroy (gameObject);
		}
		
		
	}
	
	
	
	void OnCollisionEnter2D(Collision2D other){
	if (other.gameObject.tag == "Player")
	{
		
				
		Destroy (gameObject);
	
	
	}
	}
	
	
	// Use this for initialization
	void Start () {
	
		timer = 0;
		boxSizeRegular = new Vector2(0.64f,0.53f);
		//boxSizeStart = new Vector2(0.64f,4f);
		boxSizeNow = GetComponent<BoxCollider2D>();
		
	    tipoTiro = Random.Range (0,100);
	    Debug.Log (tipoTiro);
	    
	    
	
		GameObject shovelDirection = GameObject.FindGameObjectWithTag ("Enemy");
		direction = shovelDirection.transform.localScale.x;
		
		if(tipoTiro <= 50){
		
			TiroCaindo ();
		} 
	
		
	}
	
	// Update is called once per frame
	
	void FixedUpdate(){
	
	    if(tipoTiro > 50){
	
			TiroReto();
		}
		
	}

	
	void OnDestroy(){
		//- decrease the quantity of the var firecounter on RockmanControl, to allow new shots
		//rockmanControlsv3.fireCounter--;
		//Digger1Controller.fireCounter--;
		
	}
	
	void TiroReto ()
	{
		rigidbody2D.gravityScale = 0;
		rigidbody2D.isKinematic = true;
		transform.Translate (velocidadeGosma * direction,0.0f,0);
	}
	
	
	void TiroCaindo ()
	{
		
		this.rigidbody2D.AddForce (new Vector2 (100 * velocityShovel * direction, 0));
	}
	//print (shovelDirection.transform.localScale);
	
	
	void Update(){
	
	timer += Time.deltaTime;
	
	if (timer>0.25f){
		boxSizeNow.size = boxSizeRegular;
	}
	
	}
	
}
