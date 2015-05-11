using UnityEngine;
using System.Collections;

public class Controller_Shovel : MonoBehaviour {



	public float velocityShovel;
	private float direction;
	public static int weaponDamage = 20;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			
			//===========BLOCK RETIRADO.
			// Motivo: Ao invez de fazer o tiro buscar os componentes dos inimigos para causar hit. Faremos o contrario.
			// O tiro agora apenas manda a mensagem de que colidiu. O proprio objeto que recebeu o hit vai iniciar os proprios componentes de hit, dano, etc...
			
			//other.GetComponent<ControllerNecro>().WeaponHit(true);
			//other.GetComponent<EnemyHealth>().TakeDamage (weaponDamage);
			//Debug.Log ("Acertou inimigo");
			
			//===========BLOCK RETIRADO.	
			
			Destroy (gameObject);
		
		}
		if (other.gameObject.tag == "Dirty")
		{
			Destroy (gameObject);
		}

	}

	
	// Use this for initialization
	void Start () {
		
		GameObject shovelDirection = GameObject.FindGameObjectWithTag("Player");
		direction = shovelDirection.transform.localScale.x;
		this.rigidbody2D.AddForce(new Vector2(100 * velocityShovel * direction  ,0));
		//print (shovelDirection.transform.localScale);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//===========Destroi o objeto se ele nao for mais visivel==================
		if (!renderer.isVisible)
		{
			Destroy(gameObject);
		}
		
		
	}
	
	void OnDestroy(){
		//- decrease the quantity of the var firecounter on RockmanControl, to allow new shots
		//rockmanControlsv3.fireCounter--;
		Digger1Controller.fireCounter--;
		
	}
	




}
