using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	float timer;

	void Update ()
	{
		timer += Time.deltaTime;
		if (timer > 2) {
			//if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
			Destroy (gameObject);
		}
	
	}
}
