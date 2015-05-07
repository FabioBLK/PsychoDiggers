using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	
	public float startingHealth = 100f;                            // A quantidade de energia com a qual o Inimigo começa.
	public float currentHealth;                                   // A atual quantidade de energia que o Inimigo tem
	public Image enemyHealthSlider;                                // Referencia a barra de energia do Inimigo.
	public int scoreValue = 10;	
	
	
	Animator anim;                                            // Referencia ao componente Animator
	bool isDead;                                                // Se o Inimigo esta morto
	// Verdadeiro se o inimigo foi atingido
	
	
	
	
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent <Animator> ();
		
		
		
		// Estabelece a energia inicial do Inimigo 
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		
	}
	
	
	public void TakeDamage (int amount)
	{
		
		
		// Reduz a quantidade de energia pelo dano sofrido.
		currentHealth -= amount;
		
		// Atualiza o valor da barra de energia pelo valor atual.
		enemyHealthSlider.fillAmount = currentHealth/100f;
		
		
		
		// Se o valor da energia do Inimigo atingir zero, o inimigo e destruido
		if(currentHealth <= 0 && !isDead)
		{
		    ScoreManager.scorePlayer += scoreValue;
		     isDead = true;
			// invoca a funçao de morte
			Death ();
		}
	}
	
	
	void Death ()
	{
		
		// Passa para parametro do Animator o valor de morte
		
		anim.SetBool ("isDead",true);
		BoxCollider2D box = GetComponent<BoxCollider2D>();
		box.enabled = false;
		Destroy (this.gameObject,1f);
		
		
		
		
		
		
		
		
		
	}       
}
