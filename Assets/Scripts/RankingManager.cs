using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour {

	public Text texto1,texto2,texto3;

	// Use this for initialization
	void Start () {
		PlayerPrefs.GetInt ("Score1", 0);
		PlayerPrefs.GetInt ("Score2", 0);
		PlayerPrefs.GetInt ("Score3", 0);


		//texto2 = GameObject.Find ("Text2");
		//texto3 = GameObject.Find ("Text3");

		texto1.text = PlayerPrefs.GetInt ("Score1",0).ToString ();
		texto2.text = PlayerPrefs.GetInt ("Score2",0).ToString ();
		texto3.text = PlayerPrefs.GetInt ("Score3",0).ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
