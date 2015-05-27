using UnityEngine;
using System.Collections;

public class ControllerBoss : MonoBehaviour {
	
	int triggerEnemy;
	public int awakeEnemy;
	public bool hitted;
	public Time timeHitted;	
	public float jumpPowerEnemy = 5f;	
	float hitTimer=0f;
	bool colliding;
	public LayerMask detectPlatform;
	public Transform target; // saber a posiçao do jogador a ser caçado
	public GameObject targetPlayer; // objeto player eh alvo a ser caçado
	public float playerDirection;
	float speedEnemy;
	public float maxSpeed;
	
	bool triggerEnabled=true;
	Vector4 bossRender1 = new Vector4(1,1,1,1);
	Vector4 bossRender2 = new Vector4(1,1,1,0);
	SpriteRenderer bossRender;
	float bossTime;
	float shootTime;
	public GameObject bossShot;
	public GameObject finishTrigger;
	
	Animator necroAnim;


	// Use this for initialization

	void Start () 
	{
	    //targetPlayer = GameObject.FindGameObjectWithTag ("Player");		    
	    targetPlayer = GameObject.FindObjectOfType<PlayerShadowControl>().gameObject;
	    target = targetPlayer.transform;  
		necroAnim = GetComponent<Animator> ();
		bossRender = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		bossTime += Time.deltaTime;
		shootTime += Time.deltaTime;
		
		SetInvencibility ();
		
		if (bossTime>2){
			triggerEnabled = true;
		}
		
		if (shootTime > 2){
			shootTime=0;
			GameObject shoot = Instantiate(bossShot,transform.position,Quaternion.identity)as GameObject;
		}
	
		speedEnemy = Mathf.Clamp ( speedEnemy + Time.deltaTime,0f,maxSpeed);
	
	
		//playerDirection = targetPlayer.GetComponent<Digger1Controller>().direction; // saber em qual direçao o player esta;
		playerDirection = target.localScale.x; // saber em qual direçao o player esta;
	
		
	
		if(awakeEnemy == triggerEnemy){
		
		    
		    
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
		if (triggerEnabled){
			if (col.gameObject.tag=="Shovel"){
				WeaponHit(true);
				gameObject.GetComponent<EnemyHealth>().TakeDamage (Controller_Shovel.weaponDamage);
				speedEnemy = 0;
				bossTime = 0.0f;
				print ("Boss HIT");
				
			}
			if (col.gameObject.tag == "Stomp"){
				WeaponHit(true);
				gameObject.GetComponent<EnemyHealth>().TakeDamage (Digger2StompControl.stompDamage);
				speedEnemy = 0;
				bossTime = 0.0f;
				print ("Boss HIT");
			}
		}
	}
	
	
	
	
	


	
		
	public void EnemyAwake(int triggerFlag) // Recebe a flag do GameObject TriggerEnemy e aciona o Inimigo
	{
		 
	 	triggerEnemy = triggerFlag;
	
	
	}
	
	void BlinkBoss(){
		if (bossRender.color.a == 0){
			bossRender.color = bossRender1;
			return;
		}
		if (bossRender.color.a == 1){
			bossRender.color = bossRender2;
			return;
		} 
	}
	
	void SetInvencibility ()
	{
		//Define se o personagem fica "invencivel" enquanto a variavel timer for menor que 2 (Por exemplo, ao ser atingido).
		
		if (bossTime < 2.0f) {
			triggerEnabled = false;
			BlinkBoss ();
		}
		else {
			//gameObject.layer = 0;
			bossRender.color = bossRender1;
		}
	}
	
	void OnDestroy(){
		
		if (finishTrigger != null){
			finishTrigger.SetActive(true);
		}
	}
	
	
}
