using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour {

	public Vector3 dragStart; 
	public Vector3 dragMoved;
	public Vector3 dragEnded;
	public float swipeX;
	public static float swipeY;
	public character character;
	public Rigidbody rb;
	public float smoothhorizontal;
	// Use this for initialization
	void Start () {
		character = FindObjectOfType<character> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount == 1) {
			
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Began) {
				dragStart = touch.position;
			}
			if (touch.phase == TouchPhase.Moved) {
				dragMoved = touch.position;
				if (Mathf.Abs (dragMoved.x - dragStart.x) > Mathf.Abs (dragMoved.y - dragStart.y)) {
					if ((dragStart.x > dragMoved.x + 0.1f) || (dragStart.z > dragMoved.z + 0.1f)) {
						swipeX = Mathf.Lerp(0f,-1.5f,Time.deltaTime * 6.5f);
						transform.position += new Vector3 (swipeX, 0, 0) * Time.deltaTime * character.horspeed;
						//Vector3 left = new Vector3(-0.5f,0,0);
				
						//transform.position += Vector3.Lerp(transform.position,left,2 * Time.deltaTime);

					} else if ((dragStart.x < dragMoved.x + 0.1f) || (dragStart.z > dragMoved.z + 0.1f)) {
						swipeX = Mathf.Lerp(0f,1.5f,Time.deltaTime * 6.5f);
						transform.position += new Vector3 (swipeX, 0, 0) * Time.deltaTime * character.horspeed;
						//Vector3 right = new Vector3(0.5f,0,0);
				
						//transform.position += Vector3.Lerp(transform.position,right,2 * Time.deltaTime);
					}
				} else {
					if (dragStart.y < dragEnded.y + 0.2f) {
						swipeY = 1;
						if (transform.position.y < 13f) {
							transform.position += new Vector3 (0, character.ySpeed, 0) * Time.deltaTime * character.horspeed;
							//rb.AddForce (new Vector3 (0, ySpeed, 0));
							//rb.AddForce (new Vector2 (0, swipeX * 10f));
							tilestouch.isGrounde = false;
						}
					}
				}
			}
			if (touch.phase == TouchPhase.Ended) {
				dragEnded = touch.position;
				if (Mathf.Abs (dragEnded.x - dragStart.x) > Mathf.Abs (dragEnded.y - dragStart.y)) {
					if ((dragStart.x > dragEnded.x + 0.1f) || (dragStart.z > dragEnded.z + 0.1f)) {
						swipeX = -5f;
						//transform.position += new Vector3 (swipeX, 0, 0) * Time.deltaTime * character.horspeed;
						//Vector3 left = new Vector3(-0.5f,0,0);
				
						//transform.position += Vector3.Lerp(transform.position,left,2 * Time.deltaTime);

					} else if ((dragStart.x < dragEnded.x + 0.1f) || (dragStart.z > dragEnded.z + 0.1f)) {
						swipeX = Mathf.Lerp(0f,10f,Time.deltaTime * 10);
						//transform.position += new Vector3 (swipeX, 0, 0) * Time.deltaTime * character.horspeed;
						//Vector3 right = new Vector3(0.5f,0,0);
				
						//transform.position += Vector3.Lerp(transform.position,right,2 * Time.deltaTime);
					}
				} else {
					if (dragStart.y < dragEnded.y + 0.2f) {
						swipeY = 1;
						if (transform.position.y < 5) {
							transform.position += new Vector3 (0, character.ySpeed, 0) * Time.deltaTime * character.horspeed;
							//rb.AddForce (new Vector3 (0, ySpeed, 0));
							//rb.AddForce (new Vector2 (0, swipeX * 10f));
							tilestouch.isGrounde = false;
						}
					}
				}



			}


		} else {
			// it's a tap
		}









	}

	public void GoRight () {
		swipeX = Mathf.Lerp(0f,20f,Time.deltaTime * 5);
		transform.position += new Vector3 (Mathf.Lerp(0f,20f,Time.deltaTime * 5), 0, 0) * Time.deltaTime * character.horspeed;

	}
	public void GoLeft () {
		swipeX = Mathf.Lerp(0f,-20f,Time.deltaTime * 5);
		transform.position += new Vector3 ( Mathf.Lerp(0f,-20f,Time.deltaTime * 5), 0, 0) * Time.deltaTime * character.horspeed;

	}

}
