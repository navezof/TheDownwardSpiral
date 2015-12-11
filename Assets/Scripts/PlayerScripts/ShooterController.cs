/*****************************
 * 
 * Developer : David
 * Designed for : alpha_v1
 * Description : The shooterController manage the input of the player and his speed.
 * 
 *****************************/


using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour
{
	public float 		_normalSpeed = 0.4f;
	public float 		_slowSpeed = 0.1f;
	
	// Obsolete : should be removed in next version
	public float 		_rateOfFire = 0.1f;
	
	// Main camera of the scene
	public Camera		_mCamera;
	
	// Limits of the gamescreen
	Vector3				_stage_border_width_min;
	Vector3				_stage_border_width_max;
	Vector3				_stage_border_height_min;
	Vector3				_stage_border_height_max;
	
	float				_stage_margin_vertical = 1;
	float 				_stage_margin_horizontal = 1;
	
	float 				_currentSpeed;	
	float 				_lastShoot;
	
	//Get the Launcher son, to call Shoot;
	private Launcher[] 	_shooters;
	
	void Start ()
	{
		if (_mCamera == null)
		{
			if ((_mCamera = GameObject.Find("stage_camera").camera) == null)
				Debug.LogError("Error : EnemyAI : gameobject \"_stage_camera\" is missing");
		}
				
		_currentSpeed = _normalSpeed;
		if ((_shooters = GetComponentsInChildren<Launcher>()) == null)
			Debug.LogError("Error : ShooterController : Component <Launcher> is missing");
		
		_lastShoot = Time.time;
	}
	
	/*
	 * Afin de permettre un mouvement sec, on recupere directement les inputs du clavier.
	 * Attention : Je ne sais pas ce que ca peut rendre avec un support android
	 */
	void Update ()
	{
		_stage_border_width_min = _mCamera.ScreenToWorldPoint(new Vector3 (0, 0, 30));
		_stage_border_width_max = _mCamera.ScreenToWorldPoint(new Vector3 (Screen.width, 0, 30));
		_stage_border_height_min = _mCamera.ScreenToWorldPoint(new Vector3 (0, 0, 30));
		_stage_border_height_max = _mCamera.ScreenToWorldPoint(new Vector3 (0, Screen.height, 30));
		
		// Deplacement simple
		if (Input.GetKey("up") && this.transform.position.z <= (_stage_border_height_max.z - _stage_margin_vertical))
			this.transform.position += new Vector3(0, 0, _currentSpeed);
		if (Input.GetKey("down") && this.transform.position.z >= (_stage_border_height_min.z + _stage_margin_vertical))
			this.transform.position += new Vector3(0, 0, -_currentSpeed);
		if (Input.GetKey("right") && this.transform.position.x <= (_stage_border_width_max.x - _stage_margin_horizontal))
			this.transform.position += new Vector3(_currentSpeed, 0, 0);
		if (Input.GetKey("left") && this.transform.position.x >= (_stage_border_width_min.x + _stage_margin_horizontal))
			this.transform.position += new Vector3(-_currentSpeed, 0, 0);
		
		// Tir simple
		if (Input.GetKey("z") && Time.time - _lastShoot > _rateOfFire)
		{
			_lastShoot = Time.time;
			foreach (Launcher shooter in _shooters)
				shooter.Shoot();
		}
		
		// Lancement de bombe
		if (Input.GetKey("x"))
		{
		}
		
		// Mode "precision"
		if (Input.GetKey(KeyCode.LeftShift))
			_currentSpeed = _slowSpeed;
		else
			_currentSpeed = _normalSpeed;
	}
}
