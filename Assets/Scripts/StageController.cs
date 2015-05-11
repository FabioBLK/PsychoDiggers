using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {

	GameObject player;
	int startPosition = 0;
	public GameObject[] checkPoints;

	// Use this for initialization
	void Start () {
		print (PlayerPrefs.GetInt("CheckPoint"));
		player = GameObject.FindObjectOfType<Digger1Controller>().gameObject;
		
		startPosition = PlayerPrefs.GetInt("CheckPoint");
		//startPosition = 0;
		
		player.transform.position = checkPoints[startPosition].transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
