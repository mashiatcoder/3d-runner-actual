using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour {

	public Rigidbody rb; 
	public float horspeed;
	public float vertspeed;
	public float ySpeed;
	public int score;
	public Text scoreT;
	public static bool gameover;
	public GameObject soundmanager; 
	public GameObject GroundPlatform;
	public GameObject GO;
	public GameObject Me;
	public Coin coinscript;
	public GameObject confetti;
	public float ypos;
	public float yjumpforce;
	public GameObject NewHighScore;
	public Image Mainsound;
	public Image soundon;
	public GameObject soundoff;
	public int soundint;
	public Material[] materialsofcharacter;
	//public GameObject hss;
	public enum Drink{
		coke,
		mountaindew,
		fanta,
		none,
	}
	public Drink drinks;

	void switcher(){
		switch (drinks)
		{
			case Drink.coke:
				GetComponent<MeshRenderer>().material.color = Color.red;
				break;
			case Drink.mountaindew:
				GetComponent<MeshRenderer>().material.color = Color.green;
				break;
			case Drink.fanta:
				GetComponent<MeshRenderer>().material.color = Color.yellow;
				break;	
			case Drink.none:
				GetComponent<MeshRenderer>().material.color = Color.white;
				break;	
			default:
				break;
		}
	}
	
	
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		coinscript= FindObjectOfType<Coin>();
		this.enabled = true;
		switcher();
		soundoo();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(vertspeed<9.5f){
			vertspeed += 0.000005f;

		}
		//vertspeed += 0.000005f;
		Vector3 forwardmove = transform.right * Time.deltaTime * vertspeed;

		// moving sideways
		if (Input.GetAxis ("Horizontal") > 0) {
			
			//Debug.Log(Input.GetAxis ("Horizontal"));
			transform.position += new Vector3 (Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * horspeed;
		} else if (Input.GetAxis ("Horizontal") < 0) {
			
			transform.position += new Vector3 (Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * horspeed;
		}

		//if (Input.GetMouseButtonDown (0)) {
			//if (transform.position.y < 5) {
				//transform.position += new Vector3 (0, ySpeed, 0) * Time.deltaTime * horspeed;
				//rb.AddForce (new Vector3 (0, ySpeed, 0));
				//tilestouch.isGrounde = false;
			//}
		//}
	

		JumpwithMouse ();

		if (transform.position.y > 5) {

		}
		if (transform.position.y < 2.8) {
			gameover = true;
			GameOverer ();
		}




		rb.MovePosition (rb.position  + forwardmove);


	}
	void OnTriggerEnter (Collider col) {
		if(col.gameObject.tag == "plane") {
			tilestouch.isGrounde= true;
		}
		if(col.gameObject.tag == "jumper"){
			rb.AddForce(Vector3.up * yjumpforce);
		}
		if(col.gameObject.tag == "viciousenemy") {
			gameover = true;
			GameOverer ();
			//Destroy(gameObject);
		}
	}
	public void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "viciousenemy") {
			gameover = true;
			GameOverer ();
		}
		if(col.gameObject.tag == "swing") {
				rb.AddForce(Vector3.forward * 200f);		
		}
	}

	public void GameOverer () {
		Debug.Log ("gameover"); 
		soundmanager.SetActive (false);
		GroundPlatform.SetActive (false);
		GO.SetActive (true);
		Me.SetActive (false);
		Invoke("movehs", 3f);
		//coinscript.Coins.text = coinscript.coins.ToString();
		//Highscoret.text = coinscript.hs.ToString();

		if(coinscript.score>coinscript.hs){
			confetti.SetActive(true);
			Vector3 conpos = new Vector3(0,ypos,0);
			confetti.transform.position= transform.position + conpos;
			NewHighScore.SetActive(true);
			//Invoke("condeactivate",4f);
		}
		

	}
	public void condeactivate(){
		confetti.SetActive(false);
	}
	public void movehs(){
		//hss.transform.position = new Vector3(270f,12.17601f,0f);
	}
	public void JumpwithMouse () {
		if (Input.GetMouseButtonDown (0)) {
			if (transform.position.y < 15) {
				transform.position += new Vector3 (0, ySpeed, 0) * Time.deltaTime * horspeed;
				rb.AddForce (new Vector3 (0, ySpeed, 0));
			}
		}
}
	public void soundactive(){
		//Application.OpenURL("www.google.com");
		if(PlayerPrefs.GetInt("sounds",0)==1){
			PlayerPrefs.SetInt("sounds",0);
			soundmanager.SetActive(false);
			soundoff.SetActive(true);
		}else if(PlayerPrefs.GetInt("sounds",0)==0){
			PlayerPrefs.SetInt("sounds",1);
			soundmanager.SetActive(true);
			soundoff.SetActive(false);
		
		}
	}
	public void soundoo(){
		if(PlayerPrefs.GetInt("sounds",0)==1){
			soundmanager.SetActive(true);
			soundoff.SetActive(false);
		}else if(PlayerPrefs.GetInt("sounds",0)==0){
			soundmanager.SetActive(false);
			soundoff.SetActive(true);
		
		}
	}	

	public void MaterialImageselection(){
		int selectionindex= PlayerPrefs.GetInt("characternum",0);
		if(selectionindex==0){
			Me.GetComponent<MeshRenderer>().material = materialsofcharacter[0];
		} else if(selectionindex==1){
			Me.GetComponent<MeshRenderer>().material = materialsofcharacter[1];
		}else if(selectionindex==2){
			Me.GetComponent<MeshRenderer>().material = materialsofcharacter[2];
		}else if(selectionindex==3){
			Me.GetComponent<MeshRenderer>().material = materialsofcharacter[3];
		}else if(selectionindex==4){
			Me.GetComponent<MeshRenderer>().material = materialsofcharacter[4];
		}else if(selectionindex==5){
			Me.GetComponent<MeshRenderer>().material = materialsofcharacter[5];
		}else if(selectionindex==6){
			Me.GetComponent<MeshRenderer>().material = materialsofcharacter[6];
		}else if(selectionindex==7){
			Me.GetComponent<MeshRenderer>().material = materialsofcharacter[7];
		}



	}
}
