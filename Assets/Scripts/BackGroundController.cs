using UnityEngine;
using System.Collections;

public class BackGroundController : MonoBehaviour {
	
	Camera thisCamera;
	MeshRenderer bgImage;
	
	// Use this for initialization
	void Start () {
	
	thisCamera = FindObjectOfType<Camera>();
	bgImage = GetComponent<MeshRenderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Movimenta a textura para a esquerda ou direita, de acordo com o transform X da camera
		bgImage.material.mainTextureOffset = new Vector2(thisCamera.transform.position.x/100,0);
	
	
	}
}
