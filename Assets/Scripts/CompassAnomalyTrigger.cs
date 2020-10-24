using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassAnomalyTrigger : MonoBehaviour
{
	

	void OnTriggerStay2D (Collider2D col)
	{
		if ((col.gameObject.tag == "Enemy") || ((col.gameObject.tag == "Item")))
        {
			GameObject.FindGameObjectWithTag("Compass").GetComponent<CompassRotate>().Anomaly();	
        }	
	}
	
	
}
