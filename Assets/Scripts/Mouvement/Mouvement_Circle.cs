using UnityEngine;
using System.Collections;

public class Mouvement_Circle : Mouvement
{
	public float rad;

	private Vector3 around;
	
	// Use this for initialization
	void Start ()
	{
		around = transform.position;
		transform.Translate(rad, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.RotateAround(around, Vector3.up, speed);
	}
}
