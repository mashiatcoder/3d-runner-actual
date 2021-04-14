using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {

	public GameObject GameOver;
	public GameObject player;
	public string ThisLevel;
	public string MainMenuScene;
	public string moreapps;
	public string thisapp;
	public string Store;
	public Slider slider;
	public static bool getlives = false;
	public Color white;
	public GameObject GroundPlatform;
	public GameObject sound;
	public GameObject[] objectstoff;
	
	void Start () {
		Debug.Log(Time.timeScale);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Restart(){

		SceneManager.LoadScene(ThisLevel);
	}
	public void gotomenu(){

		SceneManager.LoadScene(MainMenuScene);
	}
	public void Storescene(){

		SceneManager.LoadScene(Store);
	}
	public void moreappsgo(){

		Application.OpenURL(moreapps);
	}
	public void rateapp(){

		Application.OpenURL(thisapp);
	}



	public void VideoAdDone(){

		GameOver.SetActive(false);
		player.SetActive(true);
		if(GroundPlatform != null){

			GroundPlatform.SetActive(true);
		}

		if(player != null){
			player.transform.position+= new Vector3(0,0,4.5f);
		}
		if(sound != null){

			sound.SetActive(true);
		}		


		SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
		if(sr != null){

				sr.color = white;
		}
		getlives = true;
		if(slider != null){
			slider.value=slider.maxValue;
			

		}
		foreach (GameObject obj in objectstoff)
		{
			if(obj !=null){
			obj.SetActive(false);
			}
		}




		







	}
	


}
