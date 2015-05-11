using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	
	int triggerEnemy;
	public int awakeEnemy;
	public bool hitted;
	public Time timeHitted;	
	public float jumpPowerEnemy = 5;	
	float hitTimer=0;
	public Transform sightStart;
	public Transform sightEnd;
	public Transform sightShootAim; // variavel do gameObject de mesmo nome, inicio da linha para deteccao do player para atirar
	public Transform sightShootTarget; // variavel do gameObject de mesmo nome, fim da linha de deteccao do player para atirar
	public GameObject skullShot; // gameobject prefab para atirar caveiras
	bool colliding;
	bool collidingShoot;
	public LayerMask detectPlatform;
	public LayerMask detectPlayer;
	public Transform target; // saber a posiçao do jogador a ser caçado
	public GameObject targetPlayer; // objeto player eh alvo a ser caçado
	public float playerDirection;
	public float speedEnemy;
	int skullCounter = 0;
	public bool atiraParado;
	private static float offsetSkull = 0.90f; // variavel para definir a posicao da skull
	private float posXSkull;
	float posSkullShotX;
	float posSkullShotY;

	
	
	
	
	Animator anim;
	
	
	// Use this for initialization
	
	void Start () 
	{
		//targetPlayer = GameObject.FindGameObjectWithTag ("Player");		    
		targetPlayer = GameObject.FindObjectOfType<PlayerShadowControl>().gameObject;
		target = targetPlayer.transform;
		anim = GetComponent<Animator> ();
		
		
		
	}
	
	// Update is called once per frame
	void Update () {

		//print (offsetSkull);
		//playerDirection = targetPlayer.GetComponent<Digger1Controller>().direction; // saber em qual direçao o player esta;
		playerDirection = target.localScale.x; // saber em qual direçao o player esta;
	
		SincScalePlayer();
		
		posXSkull = transform.localScale.x * offsetSkull;
					
		colliding = Physics2D.Linecast (sightStart.position,sightEnd.position, detectPlatform); // se colidir com plataforma entao true entao salta plataforma
		collidingShoot = Physics2D.Linecast(sightShootAim.position,sightShootTarget.position,detectPlayer) ; // se colidir com player entao true para atirar
		
		
		Debug.DrawLine (sightStart.position,sightEnd.position,Color.magenta);
		Debug.DrawLine (sightShootAim.position,sightShootTarget.position,Color.red);

		
		
		if (awakeEnemy == triggerEnemy) {
		
			if (atiraParado == false) {
			
				//Debug.Log(target.position.x);
			
				anim.SetBool ("isWalking", true);
			
				//this.transform.Translate (-1 * Time.deltaTime,0,0); // pode ser deletado substituido por MoveTowards
			
				this.transform.position = Vector3.MoveTowards (this.transform.position, target.position, speedEnemy * Time.deltaTime); // posiçao do player, posiçao do inimigo, velocidade escalar do inimigo
			
				//===========Acompanha os movimentos do Player e Troca o localScale de acordo com o Scale do Player
				// se jogar estiver indo em direçao ao inimigo a frente, LocalScale -1 em relaçao ao player
				// se a posicao do inimigo estiver atras do player (em relacao a posicao 0)  sempre localScale 1 (rosto em direçao esquerda para direita)			
			
				//============================================================================================
			
			}	// fecha o if de AwakeEnemy
		
			if (colliding) {
				rigidbody2D.velocity = Vector2.up * jumpPowerEnemy;
			
			}

		}
		
		
		if(collidingShoot){
		
		
	
			if(skullCounter==10){
			
			for(int i = 0; i<=5;i++){
				



			    posSkullShotX = transform.position.x + posXSkull;
			    posSkullShotY = transform.position.y + 0.08f;

				
				
				Instantiate (skullShot,new Vector3(posSkullShotX,posSkullShotY,0),Quaternion.identity);
				skullShot.transform.localScale = this.transform.localScale;
							
			}
			
			   			    
				skullCounter = 0;
			}
			
			skullCounter += 1;
			
		
			}
			
			
		
		
		
		
		anim.SetBool ("isGetHit",hitted);
		
		
		if (hitted==true)
		{
			hitTimer += Time.deltaTime;	
		}
		
		if (hitTimer>1.5f)
		{
			hitted=false;
		}
		
		
		
	}


	void SincScalePlayer(){
	
		if (playerDirection > 0 && transform.position.x < target.position.x) {
			transform.localScale = new Vector3 (1, 1, 1);
		} else if (playerDirection < 0 && transform.position.x > target.position.x) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
	
	}
	
	
	
	void FixedUpdate(){
		
		
	}
	
	public void WeaponHit (bool weaponHit)
	{
		
		hitTimer=0;
		if (hitted == false) {
			hitted=true;
		}
		
		
	}
	
	
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag=="Shovel"){
			WeaponHit(true);
			gameObject.GetComponent<EnemyHealth>().TakeDamage (Controller_Shovel.weaponDamage);
		}
		if (col.gameObject.tag == "Stomp"){
			WeaponHit(true);
			gameObject.GetComponent<EnemyHealth>().TakeDamage (Digger2StompControl.stompDamage);
		}
	}
	
	
	
	
	
	
	
	public void EnemyAwake(int triggerFlag) // Recebe a flag do GameObject TriggerEnemy e aciona o Inimigo
	{
		
		triggerEnemy = triggerFlag;
		
		
	}
	

	
}