using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {
	
	public  GameObject bullet;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	public void Shoot() {
		Vector3 pos = transform.position;
		Instantiate(bullet, pos, Quaternion.identity);
	}
}
