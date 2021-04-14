using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformspawner : MonoBehaviour {

	public GameObject[] platformPrefabs;
	public float timediff;
	public float nexttime;
	public Transform spawn; 
	public Transform rotapos;
	public int spawnendindex;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (character.gameover = true)
			//return;
		
		if (Time.time > nexttime) {
				spawneer ();
				nexttime = Time.time + timediff;
		}
	}

	public void spawneer (){
		int plat = Random.Range (0, spawnendindex);
		GameObject platform = platformPrefabs[plat];
		GameObject platoo = Instantiate(platform, spawn.position,rotapos.rotation);
		spawn = platoo.transform.GetChild (12).transform;
	}

}
