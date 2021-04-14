using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class storescript : MonoBehaviour {
	public int coins;
	public int selected =0; 
	public int characterint;
	public string save;
	public string BackHome;
	public Text CoinsofStore;
	public GameObject NoEnoughCoins;
	public GameObject BuyButton;
	public GameObject Selectbutton;
	public GameObject myPrice;
	
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt(save,0);
		//PlayerPrefs.SetInt("characternum",0);
		//Debug.Log(characternum);
		if(PlayerPrefs.GetInt(save,0)==1){
			BuyButton.SetActive(false);
			Selectbutton.SetActive(true);
			myPrice.SetActive(false);
		}else if(PlayerPrefs.GetInt(save,0)==0){
			BuyButton.SetActive(true);
			Selectbutton.SetActive(false);
			myPrice.SetActive(true);

		}
		//PlayerPrefs.SetInt("money",11);
		coins = PlayerPrefs.GetInt("money");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Buy(){
		if(coins>= int.Parse(myPrice.GetComponent<Text>().text)){
			coins= coins - int.Parse(myPrice.GetComponent<Text>().text);
			PlayerPrefs.SetInt("money",coins);
			CoinsofStore.text = PlayerPrefs.GetInt("money").ToString();
			myPrice.SetActive(false);
			BuyButton.SetActive(false);
			Selectbutton.SetActive(true);
			selected = 1;
			PlayerPrefs.SetInt(save,selected);
		}else {
			Debug.Log("not enough coins");
			if(NoEnoughCoins != null){
				NoEnoughCoins.SetActive(true);
			}
		}
	}
	public void Select(){
		PlayerPrefs.SetInt("characternum",characterint);
		Debug.Log(characterint);
	}
	public void Home(){
		SceneManager.LoadScene(BackHome);
	}
	public void DisableNotenough(){
		NoEnoughCoins.SetActive(false);
	}
}
