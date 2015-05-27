using UnityEngine;
using System.Collections;

public class Digger1Controller : MonoBehaviour {
	Vector2 diggerVelocity;
	Rigidbody2D rb;
	[HideInInspector]
	public float direction=0;
	Animator digger1Anim;
	public GameObject Shovel;
	public GameObject digger2;
	CameraControl cameraCall;
	PlayerShadowControl playerShadowCall;
	SpriteRenderer diggerRender;
	public bool highLander;
	
	
	
	
	public GameObject explosion;
	
	public float speed =0;

	//Jump Variables
	bool ground = false;
	public GameObject groundCheck,groundCheck2;
	public float jumpPower=0;
	
	//Contator de tiros
	public static int fireCounter=0;
	
	//Damage Control
	bool diggerEnable,isDamaged;
	float diggerTimer=0;
	Vector4 blinkDigger1 = new Vector4(1,1,1,1);
	Vector4 blinkDigger2 = new Vector4(1,1,1,0);

	//sound
	public AudioClip audioJump,audioGetHit,audioDie;


	// Use this for initialization
	
	
	
	
	
	
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		digger1Anim = GetComponent<Animator> ();
		cameraCall=FindObjectOfType<CameraControl>();
		playerShadowCall = FindObjectOfType<PlayerShadowControl>();
		diggerRender = GetComponent<SpriteRenderer>();
		diggerTimer=2.0f;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//print (ground);
		
		Digger1Animation ();
		
		SetInvencibility ();
		
		//Contador e somado a cada segundo
		diggerTimer += Time.deltaTime;
		
		//Caso o contador for maior que zero, o Digger e "Habilitado"
		if (diggerTimer > 0)
		{
			EnableDigger();
		}
		
		//Se a variavel de dano for true, move o personagem na direcao oposta para simbolizar o dano
		if (isDamaged)
		{
			rigidbody2D.AddForce (Vector2.right*(transform.localScale.x*-4));
		}
		
		//Os controles naturais do player so serao possiveis caso o jogador nao tenha o status de DANO
		if (diggerEnable && diggerTimer>0)
		{
		
			PuloInput ();
			
			direction = Input.GetAxisRaw ("Horizontal") * speed;
			diggerVelocity = new Vector2 (direction, rb.velocity.y);
			rb.velocity = diggerVelocity;
			
			if (Input.GetButtonDown ("Fire1") && fireCounter < 3) // Pressionado Botao de "Tiro 1" aciona Tiro de Pa
			{
				digger1Anim.SetTrigger("Fire");
				Instantiate(Shovel, transform.position, Quaternion.identity) ;
				Shovel.transform.localScale = this.transform.localScale;
				fireCounter++;
			}
			
			//Troca de personagem ao pressionar a tecla " "
			if (Input.GetKeyDown (KeyCode.C) && ground && diggerTimer>2.0f){
				ChangePlayer();
			}
		}
	
	}
	
	void FixedUpdate(){
		//====================GROUND CHECK===================
		//checa a cada frame se o personagem esta ou nao no chao. E define o valor na variavel ground
		ground = (Physics2D.Linecast (transform.position,groundCheck.transform.position,1 << LayerMask.NameToLayer("Plataforma")) || Physics2D.Linecast (transform.position,groundCheck2.transform.position,1 << LayerMask.NameToLayer("Plataforma")));
		 
	}
	
	
	void PuloInput ()
	{
		//Ao pressionar o botao de pulo E TAMBEM se o personagem estiver no chao, inicia Metodo Jump()
		if (Input.GetButtonDown ("Jump") && ground) {
			Jump ();
		}
		//Caso o Botao de pulo for "solto" E TAMBEM estiver no ar, inicia o metodo que anula a força do pulo JumpCancel()
		if (Input.GetButtonUp ("Jump") && !ground) {
			JumpCancel ();
		}
	}
	
	
	void Jump(){
		audio.PlayOneShot (audioJump);
		//Adiciona força no eixo Y do personagem. Força do pulo definido na variavel JumpPower (Publica)
		rigidbody2D.velocity = (Vector2.up*jumpPower);
	}
	
	
	void JumpCancel(){
		//Cancela a força do pulo no ar. Dessa forma o jogador pode controlar a altura do pulo, no estilo Super Mario.
		if (rigidbody2D.velocity.y>0){
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,Mathf.Lerp (rigidbody2D.velocity.y,0.0f,120*Time.deltaTime));
		}
	}
	

	void Digger1Animation(){

		if (direction > 0) {
			transform.localScale = new Vector3(1,1,1);
			digger1Anim.SetBool ("isWalking",true);
		}

		if (direction < 0) {
			transform.localScale = new Vector3(-1,1,1);
			digger1Anim.SetBool ("isWalking",true);
		}

		if (direction == 0) {
			digger1Anim.SetBool ("isWalking",false);
		}
		
		//Caso o personagem esteja no chao, seta a bool de animacao "isGrounded" com o mesmo valor
		digger1Anim.SetBool ("isGrounded",ground);
		
		//define a variavel float de animacao "ySpeed" com o mesmo valor da velocidade do eixo Y do personagem. Necessario para mudar os frames do Blend Tree de animacao "Jump"
		digger1Anim.SetFloat ("ySpeed",rigidbody2D.velocity.y);
	}
	
	void ChangePlayer(){
		
		// Instancia o segundo player na tela / Chama o metodo da camera para que ela procure o segundo player / Destroi o player atual
		float scaleX=transform.localScale.x;
		GameObject newDigger = Instantiate (digger2,transform.position,Quaternion.identity) as GameObject;
		newDigger.transform.localScale=new Vector3(scaleX,1,1);
		Instantiate (explosion, new Vector3(transform.position.x,transform.position.y-1,transform.position.z),Quaternion.identity);
		cameraCall.ChangeToDigger2();
		playerShadowCall.ChangeToDigger2();
		//LifeManager.playerLives -= 1;
		PlayerFaceManager.iFace = 1;
		Destroy (gameObject);
		
	}
	
	public void EnableDigger()
	{
		diggerEnable = true;
		digger1Anim.SetBool("Damage", false);
		isDamaged = false;
		rigidbody2D.gravityScale = 1;
		//gameObject.layer = 0;
		
	}
	
	public void PauseDigger()
	{
		direction = 0;
		diggerEnable = false;
		diggerTimer = -1;
		//if (!isDamaged)
		//{
			rigidbody2D.velocity = new Vector2(0, 0);
			//rigidbody2D.gravityScale = 0;
		//}
	}
	
	public void PauseDiggerFinish(float tempo)
	{
		direction = 0;
		diggerEnable = false;
		diggerTimer = tempo;
		//if (!isDamaged)
		//{
		rigidbody2D.velocity = new Vector2(0, 0);
		//rigidbody2D.gravityScale = 0;
		//}
	}
	
	void Damage()
	{
		audio.PlayOneShot (audioGetHit);
		if(highLander == false){
		
		PauseDigger();
		digger1Anim.SetBool("Damage", true);
		isDamaged = true;
		rigidbody2D.gravityScale = 1;
		rigidbody2D.velocity = new Vector2(0,0);
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		//Enemies Collision
		if (col.collider.tag == "Enemy" || col.collider.tag == "Hazard")
		{
			Damage();
		}
	}
	
	
	void OnTriggerEnter2D(Collider2D otherCol)
	{
		//Destruidor Collision
		if (otherCol.gameObject.name == "Destruidor")
		{
			rigidbody2D.gravityScale = 0;
			Damage ();
		}
	}
	
	
	void BlinkDigger(){
		if (diggerRender.color.a == 0){
			diggerRender.color = blinkDigger1;
			return;
		}
		if (diggerRender.color.a == 1){
			diggerRender.color = blinkDigger2;
			return;
		} 
	}

	void SetInvencibility ()
	{
		//Define se o personagem fica "invencivel" enquanto a variavel timer for menor que 2 (Por exemplo, ao ser atingido).
		
		if (diggerTimer < 2.0f) {
			gameObject.layer = 9;
			BlinkDigger ();
		}
		else {
			gameObject.layer = 0;
			diggerRender.color = blinkDigger1;
		}
	}
	
	public void ReduceOneLife(){
		//reduz uma vida no contador do personagem.
		//====ATENCAO==
		//Essa funcao e' ativada pela animacao "DAMAGE"
		LifeManager.playerLives -= 1;
		if (LifeManager.playerLives < 0){
			audio.PlayOneShot (audioDie);
			digger1Anim.SetBool ("Die",true);
		}
	}
}
