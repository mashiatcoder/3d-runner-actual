using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

	public Text scoreT;
	public int score;
	public Text Coins;
	public int coins;
	public Text GOscore;
	public int hs;
	public Text HighScoreT;
	public GameObject highscorett;
	public GameObject coinsup;



	// Use this for initialization
	void Start () {
		int score = 0;
		 hs=PlayerPrefs.GetInt("highs");
		 coins=PlayerPrefs.GetInt("money",0);
		//PlayerPrefs.DeleteKey("coins");
		highscorett.GetComponent<Text>().text = hs.ToString();
		//HighScoreT.text =  PlayerPrefs.GetInt("highs",0).ToString();
		Coins.text = coins.ToString();
		//Coins.text = PlayerPrefs.GetInt("money",0).ToString ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "coins") {
			Destroy (col.gameObject);
			score++;
			scoreT.text = score.ToString ();
			GOscore.text = score.ToString ();
			if(score > PlayerPrefs.GetInt("highs", 0)){
				hs = score;
				PlayerPrefs.SetInt("highs",hs);
				HighScoreT.text = PlayerPrefs.GetInt("highs").ToString();
				//confetti.SetActive(true);
				Vector3 confettipos = new Vector3(0,0,0);
				//confetti.transform.position = transform.position;
			}

			coins++;
			//Coins.text = coins.ToString ();
			PlayerPrefs.SetInt("money", coins);
			Coins.text = PlayerPrefs.GetInt("money").ToString ();
			GameObject coinsupper = Instantiate(coinsup,col.transform.position,coinsup.transform.rotation);
			Destroy(coinsupper, 4f);
			//Coins.text = coins.ToString ();
		}
	}
}
