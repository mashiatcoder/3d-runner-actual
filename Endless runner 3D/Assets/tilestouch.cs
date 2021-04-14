using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tilestouch : MonoBehaviour {

	//public Transform spawn;
	//public GameObject prefab;
	//public int touchC;
	//public Text touchCtxt;
	public static bool isGrounde;
	public float timeto;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//public void OnCollisionEnter (Collision col){
		//if (col.gameObject.tag == "Player") {
			//touchC++;
			//touchCtxt.text = touchC.ToString ();
			//if (touchC < 2) {
			//GameObject tile = Instantiate (prefab, spawn.position, transform.rotation);
			//spawn = tile.transform.GetChild (13).transform;
			//isGrounde = true;
			//}//Destroy (gameObject, 3f);
		//}
	//}

	//public void OnTriggerStay (Collider col){
		//if (col.gameObject.tag == "Player") {
		//	isGrounde = true;
		//}
	//}
		
	 public void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "Player") {
			//Instantiate (prefab, spawn.position, transform.rotation);
			//if (isGrounde = true) {
				Destroy (gameObject, timeto);

			}
		}
	//}

}
