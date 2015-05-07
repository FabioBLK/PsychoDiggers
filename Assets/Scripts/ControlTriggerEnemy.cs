using UnityEngine;
using System.Collections;

public class ControlTriggerEnemy : MonoBehaviour {

	int triggerFlag;
	//public GameObject[] awakeEnemies;
	EnemyController[] awakeEnemies;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Player") 
		{
						
			triggerFlag += 1;
			
			//awakeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
			awakeEnemies = GetComponentsInChildren<EnemyController>();
			 
			 
			//foreach(GameObject awakeEnemy in awakeEnemies){
			foreach(EnemyController awakeEnemy in awakeEnemies){
				//awakeEnemy.GetComponent<EnemyController>().EnemyAwake(triggerFlag);
				awakeEnemy.EnemyAwake (triggerFlag);
			}
			
			 
			 //Destroy (this.gameObject);
			 gameObject.collider2D.enabled= false;
           
         }
      }
}