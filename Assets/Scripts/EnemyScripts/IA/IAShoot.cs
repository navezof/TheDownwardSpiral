using UnityEngine;
using System.Collections;

// Class Model pour les comportments de l'ia.

public class IAShoot : MonoBehaviour {
	public float Rate_of_Fire = 0.5f;
	
	private float my_timer;
	private Launcher[] shooters;
	
	// Use this for initialization
	void Start () {
		my_timer = Time.time;
		shooters = GetComponentsInChildren<Launcher>();		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > my_timer) {
			fire();
		}
	}
	
	void inPosition() {
		//turn or move the Launchers
	}
	
	void Engage() {
		//Animation or delay if the weapond need to be charge

	}
	
	void fire() {
		//Call shoot methode foreach launchers
		foreach (Launcher shooter in shooters) {
			shooter.Shoot();
		}
		Reaload();
	}
	
	void Reaload() {
		//Init the timer for the new launch.	
		my_timer = Time.time + Rate_of_Fire;
	}
}
