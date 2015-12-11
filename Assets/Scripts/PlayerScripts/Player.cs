/*****************************
 * 
 * Developer : David
 * Designed for : alpha_v1
 * Description : Manage the player mechanics.
 * 
 *****************************/

using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
	public GameObject	_armor;
	
	private float 		_currentLife;
	private float		_currentBomb;
	private float		_score;
	
	public float		_default_startingLife = 3.0f;
	public float		_default_startingBomb = 2.0f;
	
	private bool		_invincible;
	private float		_invincibleStart;
	public float		_invincibleDuration;
	
	public Transform	_spawnAnchor;
	
	public	int			_levelCombo;
	
	void Start ()
	{
		initArmor();
	}
	
	void initArmor()
	{
		if (_armor != null && _armor.GetComponent<Armor>() != null)
		{
			_currentLife = _armor.GetComponent<Armor>().getStartingLife();
			_currentBomb = _armor.GetComponent<Armor>().getStartingBomb();
		}
		else
		{
			Debug.Log("Warning : Player : armor missing.");
			_currentLife = _default_startingLife;
			_currentBomb = _default_startingBomb;
		}
	}
	
	public void Update()
	{
		if ((float) Time.time - _invincibleStart > _invincibleDuration)
			_invincible = false;
	}
	
	public void Die()
	{
		if (!_invincible)
		{
			_armor.GetComponent<Armor>().Die();
			if (_currentLife <= 0)
				SendMessageUpwards("GameOver");
			else
			{
				//transform.position = Vector3.Lerp(transform.position, _stage.transform.position, 0.5f);
				_currentLife--;
				_invincible = true;
				_invincibleStart = Time.time;
			}
		}
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, 100, 25), "Life : " + _currentLife);
		GUI.Box(new Rect(0, 30, 100, 25), "Bomb : " + _currentBomb);
		GUI.Box(new Rect(0, 60, 100, 25), "Score : " + _score);

		if (_invincible)
		{
			float timeelapsed = _invincibleDuration - (Time.time - _invincibleStart);
			GUI.Box(new Rect(0, 90, 100, 25), "Invincible : " + timeelapsed);
		}
	}
}
