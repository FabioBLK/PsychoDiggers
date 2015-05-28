using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour {

	public Text texto1,texto2,texto3;
	public Button botao1,botaoOK;
	public InputField campoInput;
	int[] scoreArray;
	string[] nameArray;
	
	// Use this for initialization
	void Start () {
		
		botao1.interactable = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void EnableRanking(){
		
		
		print (campoInput.text);
		
		botao1.interactable = true;
		
		PlayerPrefs.SetString ("ThisName",campoInput.text);
		
		Destroy(campoInput);
		botaoOK.GetComponentInChildren<Text>().text = "RANKING";
		Destroy(botaoOK);
		
		texto1.enabled = true;
		texto2.enabled = true;
		texto3.enabled = true;
		botao1.enabled = true;
		
		scoreArray = new int[5];
		nameArray = new string[5];
		
		scoreArray[0]=PlayerPrefs.GetInt ("Score1",0);
		scoreArray[1]=PlayerPrefs.GetInt ("Score2",0);
		scoreArray[2]=PlayerPrefs.GetInt ("Score3",0);
		scoreArray[3]=0;
		scoreArray[4]=0;
		
		nameArray[0]=PlayerPrefs.GetString("Name1","Null1");
		nameArray[1]=PlayerPrefs.GetString("Name2","Null2");
		nameArray[2]=PlayerPrefs.GetString("Name3","Null3");
		nameArray[3]="Null4";
		nameArray[4]="Null5";
		
		
		for (int i =0; i<scoreArray.Length-2;i++){
			if (PlayerPrefs.GetInt ("ThisScore")>scoreArray[i]){
				scoreArray[i+2]=scoreArray[i+1];
				scoreArray[i+1]=scoreArray[i];
				scoreArray[i]=PlayerPrefs.GetInt("ThisScore");
				nameArray[1+2]=nameArray[i+1];
				nameArray[i+1]=nameArray[i];
				nameArray[i]=PlayerPrefs.GetString("ThisName","Null");
				break;
			}
		}
		
		PlayerPrefs.SetInt ("Score1",scoreArray[0]);
		PlayerPrefs.SetInt ("Score2",scoreArray[1]);
		PlayerPrefs.SetInt ("Score3",scoreArray[2]);
		
		PlayerPrefs.SetString ("Name1",nameArray[0]);
		PlayerPrefs.SetString ("Name2",nameArray[1]);
		PlayerPrefs.SetString ("Name3",nameArray[2]);
		
		//PlayerPrefs.SetString("Name1","TESTE01");
		
		texto1.text = (PlayerPrefs.GetString("Name1","Teste") + " " + PlayerPrefs.GetInt ("Score1",0).ToString ());
		texto2.text = (PlayerPrefs.GetString("Name2","Teste") + " " + PlayerPrefs.GetInt ("Score2",0).ToString ());
		texto3.text = (PlayerPrefs.GetString("Name3","Teste") + " " + PlayerPrefs.GetInt ("Score3",0).ToString ());
		
	}
	
	public void ClearRanking(){
		PlayerPrefs.SetInt ("Score1",0);
		PlayerPrefs.SetInt ("Score2",0);
		PlayerPrefs.SetInt ("Score3",0);
		
		PlayerPrefs.SetString ("Name1","ABC");
		PlayerPrefs.SetString ("Name2","DEF");
		PlayerPrefs.SetString ("Name3","GHI");
	}
	
}

