using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCyl : MonoBehaviour {
	public float rotaspeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up,rotaspeed * Time.deltaTime);
		Quaternion.AngleAxis(rotaspeed, Vector3.up);
	}
}
