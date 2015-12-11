using UnityEngine;
using System.Collections;

public class Mouvement_Line : Mouvement {
	public int x;
	public int y;
	public int z;
		
	void Start () {
	 if (x > 0) {
			x = 1;
		} else if (x < 0) {
			x = -1;
		}
			 if (y > 0) {
			y = 1;
		} else if (y < 0) {
			y = -1;
		}
			 if (z > 0) {
			z = 1;
		} else if (x < 0) {
			z = -1;
		}
	}
	
	void Update ()
	{
		transform.Translate (x * speed, y * speed, z * speed);
	}	
}
