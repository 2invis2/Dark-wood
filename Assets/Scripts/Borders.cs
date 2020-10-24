using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player")
			{
				col.gameObject.transform.position = new Vector3(-col.gameObject.transform.position.x*0.9f, -col.gameObject.transform.position.y*0.9f, col.gameObject.transform.position.z);
				Debug.Log("border reached");
			}
	}
}
