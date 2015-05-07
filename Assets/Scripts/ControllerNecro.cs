using UnityEngine;
using System.Collections;

public class ControllerNecro : MonoBehaviour {
	
	int triggerEnemy;
	public int awakeEnemy;
	public bool hitted;
	public Time timeHitted;	
	public float jumpPowerEnemy = 5;	
	float hitTimer=0;
	bool colliding;
	public LayerMask detectPlatform;
	public Transform target; // saber a posiçao do jogador a ser caçado
	public GameObject targetPlayer; // objeto player eh alvo a ser caçado
	public float playerDirection;
	public float speedEnemy;
	
	
	Animator necroAnim;


	// Use this for initialization

	void Start () 
	{
	    //targetPlayer = GameObject.FindGameObjectWithTag ("Player");		    
	    targetPlayer = GameObject.FindObjectOfType<PlayerShadowControl>().gameObject;
	    target = targetPlayer.transform;  
		necroAnim = GetComponent<Animator> ();
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
		//playerDirection = targetPlayer.GetComponent<Digger1Controller>().direction; // saber em qual direçao o player esta;
		playerDirection = target.localScale.x; // saber em qual direçao o player esta;
	
		
	
		if(awakeEnemy == triggerEnemy){
		
		 //Debug.Log(target.position.x);
		    
			necroAnim.SetBool ("isWalking",true);
			
			//this.transform.Translate (-1 * Time.deltaTime,0,0); // pode ser deletado substituido por MoveTowards
			
			this.transform.position = Vector3.MoveTowards(this.transform.position,target.position,speedEnemy * Time.deltaTime); // posiçao do player, posiçao do inimigo, velocidade escalar do inimigo
			
			//===========Acompanha os movimentos do Player e Troca o localScale de acordo com o Scale do Player
			// se jogar estiver indo em direçao ao inimigo a frente, LocalScale -1 em relaçao ao player
			// se a posicao do inimigo estiver atras do player (em relacao a posicao 0)  sempre localScale 1 (rosto em direçao esquerda para direita)			
			
			if (playerDirection> 0 && transform.position.x < target.position.x) { 
				transform.localScale = new Vector3(1,1,1);}
									
			else if (playerDirection< 0 && transform.position.x > target.position.x) {
				transform.localScale = new Vector3(-1,1,1);}
				
		 //============================================================================================
	
}	// fecha o if de AwakeEnemy
		
	 
		
		
	
    
	necroAnim.SetBool ("isGetHit",hitted);
	if (hitted==true)
	{
		hitTimer += Time.deltaTime;	
	}
	
	if (hitTimer>1.5f)
	{
		hitted=false;
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
