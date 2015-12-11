/*****************************
 * 
 * Developer : David
 * Designed for : alpha_v1
 * Description : Manage the main game mechanics.
 * 
 *****************************/
using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{
	public bool 		_scrolling_on = false;
	public float 		_scrollingSpeed;
	
	// Position of the end of the stage
	public float 		_end_of_stage;
		
	public GameObject 	_player;
	
	private bool 		_gameover = false;
	private bool 		_endgame = false;
	
	private float		_defaultStageSpeed = 0.1f;
	
	void Start()
	{
		if (_scrollingSpeed == 0)
			_scrollingSpeed = _defaultStageSpeed;
		if (_player == null)
		{
			if ((_player = GameObject.Find("Player")) == null)
				Debug.LogError("Error : GameScrupt : gameobject \"_player\" is missing");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_scrolling_on)
		{
			if (this.transform.position.z <= _end_of_stage)
				this.transform.position += new Vector3(0, 0, _scrollingSpeed);
			else
			{
				_scrollingSpeed = 0;				
				_endgame = true;
			}
		}
	}
	
	void GameOver()
	{
		_scrolling_on = false;
		_gameover = true;
	}
	
	void OnGUI()
	{
		if (_gameover)
		{
			GUI.Box(new Rect(Screen.width/2, Screen.height/2, 150, 25), "GAMEOVER");
		}
		if (_endgame)
		{
			GUI.Box(new Rect(Screen.width/2, Screen.height/2, 150, 25), "End of the Stage");
		}
	}
}
