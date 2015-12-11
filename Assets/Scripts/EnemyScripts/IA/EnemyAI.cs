/*****************************
 * 
 * Developer : David
 * Designed for : alpha_v1
 * Description : This class manage the activation of an enemy and all of its components.
 * 
 *****************************/

using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
	public enum EType 
	{
		RED,
		BLUE,
		GREEN
	}
	
	// Point used as reference for the activation of the mob
	public GameObject 	_stage_camera;
	
	// Distance where the enemy activate itself
	public float 		_activationRange;
	
	// isAlive if in the range of activation
	public bool 		_isAlive = false;
	
	/* Mob properties */
	public EType		_type = EType.RED;
	
	void Start ()
	{
		if (_stage_camera == null)
		{
			if ((_stage_camera = GameObject.Find("stage_camera")) == null)
				Debug.LogError("Error : EnemyAI : gameobject \"_stage_camera\" is missing");
		}
		if (this.gameObject.GetComponent<IAShoot>() == null)
			Debug.LogError("Error : EnemyAI : Component <IAShoot> is missing");
		else
			this.gameObject.GetComponent<IAShoot>().enabled = false;

		if (this.gameObject.GetComponent<Mouvement>() == null)
			Debug.LogError("Error : EnemyAI : Component <Mouvement> is missing");
		else
			this.gameObject.GetComponent<Mouvement>().enabled = false;
	}
	
	void Update ()
	{
		// Activation of the enemy if in the activation range
		if (!_isAlive)
		{
			float _temp_distance = Vector3.Distance(transform.position, _stage_camera.transform.position);
			if (_temp_distance <= _activationRange)
				setAlive();
		}
	}
	
	/*
	 * Activate the mob, its movements and shoot routine
	 */
	public void setAlive()
	{
		if (!_isAlive)
		{
			_isAlive = true;
			if (this.gameObject.GetComponent<IAShoot>() == null)
			Debug.LogError("Error : EnemyAI : Component <IAShoot> is missing");
		else
			this.gameObject.GetComponent<IAShoot>().enabled = true;

		if (this.gameObject.GetComponent<Mouvement>() == null)
			Debug.LogError("Error : EnemyAI : Component <Mouvement> is missing");
		else
			this.gameObject.GetComponent<Mouvement>().enabled = true;
		}
	}
}
