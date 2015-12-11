using UnityEngine;
using System.Collections;

public class Mouvement_Cos : Mouvement {
	public float rad;
	public bool cas_on_x;
	public bool cas_on_z;
	public float speed_on_rad;

	void Start () {
	}
	
	void Update () {
		if (cas_on_x) {
	    transform.Translate (speed, 0, Mathf.Cos(transform.position.x * (1 / rad)) * speed_on_rad);	
		}
		
		if (cas_on_z) {
	    transform.Translate (Mathf.Cos(transform.position.z * (1 / rad)) * speed_on_rad, 0, speed);				
		}
	}	
}

