using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour
{
	public bool destroyEnemy;
	public bool destroyPlayer;
	
	void OnTriggerEnter(Collider other)
	{
		if (destroyEnemy)
		{
			if (other.gameObject.tag == "Enemy")
			{
				Destroy(other.gameObject);
				Destroy(gameObject);
			}
		}
		else if (destroyPlayer)
		{
			if (other.gameObject.tag == "Player")
			{
				if (other.gameObject.GetComponent<Player>() == null)
					Debug.LogError("Error : Collision : Component <Player> is missing");
				else
					other.gameObject.GetComponent<Player>().Die();
				//Destroy(gameObject);
			}
		}
		
	}
}
