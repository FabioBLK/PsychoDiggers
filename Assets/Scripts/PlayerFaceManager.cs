using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerFaceManager : MonoBehaviour {
public static int iFace;
public Sprite[] playerFaceSprite = new Sprite[2];
public Image imageSource;

	// Use this for initialization
	void Start () {
	imageSource = GetComponent<Image>();
	imageSource.sprite = playerFaceSprite[iFace];
	
	}
	
	// Update is called once per frame
	void Update () {
		imageSource.sprite = playerFaceSprite[iFace];
		//Debug.Log (iFace.ToString ());
	}
	
   
	
	
}
