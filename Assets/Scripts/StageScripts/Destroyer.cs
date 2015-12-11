using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Stage")
		{
			if (other.gameObject.tag == "Enemy")
			{
				if (other.GetComponent<EnemyAI>()._isAlive == true)
				{
					//print (this.transform.name + " destroy enemy : " + other.name);
					Destroy(other.gameObject);
				}
			}
			else
			{
				Destroy(other.gameObject);
			}
		}
	}
}
