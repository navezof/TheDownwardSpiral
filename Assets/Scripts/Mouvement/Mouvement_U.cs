using UnityEngine;
using System.Collections;

public class Mouvement_U : Mouvement {
	
	public float dist_in_line;
	public float dist_ref_x;
	public float dist_ref_z;
	public float degree;
	

	//refeerence qui sera le centre de l'arc de cercle
	private Vector3 around_ref;
	private Vector3 init_pos;
	private int status;
	private float mov_degree;
	bool degree_neg;
	// Use this for initialization
	void Start () {
		init_pos = transform.position;
		init_pos.x += dist_in_line;
		status = 0;
		mov_degree = 0;
		if (degree < 0) {
			degree_neg = true;
			degree *= -1;
		} else {
		degree_neg = false;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (status == 0) {
			if (init_pos.x > transform.position.x) {
				transform.Translate(speed, 0, 0);
			} else {
				status = 1;
				init_pos = transform.position;
				init_pos.x += dist_ref_x;
				init_pos.z += dist_ref_z;
			}	
		} else if (status == 1) {
			if (mov_degree < degree) {
				if (!degree_neg) {
				transform.RotateAround(init_pos, Vector3.up, 10 * speed);
				} else {
				transform.RotateAround(init_pos, Vector3.up, -10 * speed);
				}
			} else {
				status = 2;
			}
			mov_degree += 10 * speed;
		} else if (status == 2) {
			transform.Translate(speed, 0, 0);	
		}
	}
}
