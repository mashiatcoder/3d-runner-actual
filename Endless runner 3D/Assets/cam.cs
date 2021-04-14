using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour {
	Vector3 offset;
	public Transform player;
	public float cameraY;
	public Color[] colors;
	public int indexofbg;
	// Use this for initialization
	void Start () {
		cameraY = transform.position.y;
		if(player != null){
		offset = player.position - transform.position;
		}
		//cam = Camera.main;
		int colorindex = Random.Range(0,indexofbg);
		Color meracolor = colors[colorindex];
		Camera.main.backgroundColor = meracolor;

	}
	
	// Update is called once per frame
	void Update () {
		if(player != null){
		Vector3 temp = player.position - offset;
		temp.y = cameraY;
		transform.position = temp;
		}
	}
}
