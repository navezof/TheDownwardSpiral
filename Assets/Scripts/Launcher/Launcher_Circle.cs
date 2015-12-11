using UnityEngine;
using System.Collections;

public class Launcher_Circle : MonoBehaviour {
	
	public  GameObject bullet;
	public 	float range;
	public 	int nb_object;

	
	private float space_bt_obj;
	private Vector3 my_ref_pos;
	private Vector3 my_new_pos;
	private Quaternion my_init_rot;

	
	
	// Use this for initialization
	void Start () {
		space_bt_obj = 360 / (nb_object);
		my_ref_pos = transform.position;
		transform.Translate(range, 0, 0);
		my_new_pos = transform.position;
		my_init_rot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void Shoot() {
		int i = -1;
		while (i <= nb_object) {
			Vector3 pos = transform.position;
			// Les bullets ne sont pas encore orienté.
			Instantiate(bullet, pos, transform.rotation);
			transform.RotateAround(my_ref_pos, Vector3.up, space_bt_obj);
			i++;
		}
		transform.position = my_new_pos;
		transform.rotation = my_init_rot;
	}
}

