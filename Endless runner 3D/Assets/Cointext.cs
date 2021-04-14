using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cointext : MonoBehaviour {
	public Text Coin;
	public int coin;
	// Use this for initialization
	
	void Start () {
		//coin = PlayerPrefs.GetInt("money");
		Coin.text = PlayerPrefs.GetInt("money").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
