using UnityEngine;
using System.Collections;

public class SkullShotControl : MonoBehaviour {

	public float velocityWeapon;
	private float direction;
	public static int weaponDamage = 20;
	
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
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
		if (other.gameObject.tag == "Plataforma")
		{
			Destroy (this.gameObject);
		}
		
	}
	
	
	// Use this for initialization
	void Start () {
		GameObject weaponDirection = GameObject.FindGameObjectWithTag("Enemy");
		direction = weaponDirection.transform.localScale.x;
		this.rigidbody2D.AddForce(new Vector2(100 * velocityWeapon * direction,0));
	
		
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//===========Destroi o objeto se ele nao for mais visivel==================
		if (!renderer.isVisible)
		{
			Destroy(gameObject);
		}
		
		
	}



	
	
}
