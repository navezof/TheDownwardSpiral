/*****************************
 * 
 * Developer : David
 * Designed for : alpha_v1
 * Description : Hold of the characteristics needed.
 * 
 *****************************/

using UnityEngine;
using System.Collections;

public class Armor : MonoBehaviour
{
	// Upgradable properties through money
	public GameObject		_mainWeapon;
	public GameObject		_missileWeapon;
	public GameObject		_bomb;
	public GameObject		_overdrive;
		
	// Upgradable properties through experience
	public float			_startingLife;
	public float			_startingBomb;
	public float			_overdriveColliderSize;
	
	// Fixed properties
	public string 			_name;
	public float			_speed;
	public EnemyAI.EType	_type;
	// public Launcher.EType[] , weapon useable by this armor
	
	void Start ()
	{
		if (_mainWeapon == null)
			Debug.Log("Warning : Armor : mainWeapon missing.");
		if (_missileWeapon == null)
			Debug.Log("Warning : Armor : missileWeapon missing.");
		if (_bomb == null)
			Debug.Log("Warning : Armor : bomb missing.");
		if (_overdrive == null)
			Debug.Log("Warning : Armor : overdrive missing.");			
	}
	
	public void Die()
	{
		Debug.Log("Motor down");
		//Instantiate(this.transform.parent, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
		//DestroyObject(this);
	}
	
	public float getStartingLife() { return _startingLife; }
	public float getStartingBomb() { return _startingBomb; }
}
