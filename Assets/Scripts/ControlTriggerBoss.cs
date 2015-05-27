using UnityEngine;
using System.Collections;

public class ControlTriggerBoss : MonoBehaviour {
	
	int triggerFlag;
	//public GameObject[] awakeEnemies;
	ControllerBoss awakeEnemy;
	public GameObject boss;
	
	
	// Use this for initialization
	void Start () {
	
	awakeEnemy = boss.GetComponent<ControllerBoss>();

		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "Player") 
		{
			
			triggerFlag += 1;
			
				Debug.Log (awakeEnemy);		
				awakeEnemy.EnemyAwake (triggerFlag);
				//Destroy (this.gameObject);
				gameObject.collider2D.enabled= false;
			
			}
			
			

			
		}
	}
