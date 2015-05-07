using UnityEngine;
using System.Collections;

public class TriggerBoss : MonoBehaviour {
	
	public int triggerFlag;
	public GameObject awakeBoss;
	
	
	
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
			
			awakeBoss = GameObject.FindGameObjectWithTag("Boss");
			
			awakeBoss.GetComponent<ControllerNecro>().EnemyAwake(triggerFlag);
				
				
						
			Destroy (this.gameObject);
			
		}
	}
}